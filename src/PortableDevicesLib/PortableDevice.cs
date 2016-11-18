/*
 * Created by SharpDevelop.
 * User: jaran
 * Date: 05.11.2012
 * Time: 19:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using PortableDeviceApiLib;
using Common.Logging;
using System.IO;
using System.Linq;
using PortableDevicesLib;

namespace PortableDevicesLib.Domain
{

    /// <summary>
    /// Source: https://msdn.microsoft.com/en-us/library/windows/hardware/ff597867(v=vs.85).aspx
    /// </summary>
    public enum WPD_DEVICE_TYPES
    {
        GENERIC = 0,
        CAMERA = 1,
        MEDIA_PLAYER = 2,
        PHONE = 3
    };

    public class PortableDevice
    {
        private ILog l = LogManager.GetLogger(typeof(PortableDevice));

        private readonly PortableDeviceClass _device;
        private bool _isConnected;

        public string DeviceID { get; set; }

        public string FriendlyName { get; set; }
        public string Model { get; set; }
        public WPD_DEVICE_TYPES Type { get; set; }
        public string Manufacturer { get; set; }

        public PortableDevice(string deviceID)
        {
            this.DeviceID = deviceID;
            _device = new PortableDeviceClass();

            Connect();
            GetPropertiesFromDevice();
            Disconnect();

            _isConnected = false;
        }

        void ValidateConnection()
        {
            if (_device == null)
            {
                throw new InvalidOperationException("Not connected to device.");
            }
        }

        public void Connect()
        {
            if (this._isConnected) { return; }
            var clientInfo = (IPortableDeviceValues)new PortableDeviceTypesLib.PortableDeviceValuesClass();
            _device.Open(DeviceID, clientInfo);
            _isConnected = true;
        }

        public void Disconnect()
        {
            if (!_isConnected) { return; }
            _device.Close();
            _isConnected = false;
        }

        private void GetPropertiesFromDevice()
        {
            // Retrieve the properties of the device
            IPortableDeviceContent content;
            IPortableDeviceProperties properties;
            _device.Content(out content);
            content.Properties(out properties);

            // Retrieve the values for the properties
            IPortableDeviceValues propertyValues;
            properties.GetValues("DEVICE", null, out propertyValues);

            // Retrieve speciffic values:
            string friendlyName;
            propertyValues.GetStringValue(ref DevicePropertyKeys.WPD_DEVICE_FRIENDLY_NAME, out friendlyName);
            this.FriendlyName = friendlyName;

            string deviceModel;
            propertyValues.GetStringValue(ref DevicePropertyKeys.WPD_DEVICE_MODEL, out deviceModel);                        
            this.Model = deviceModel;

            int deviceType;
            propertyValues.GetSignedIntegerValue(ref DevicePropertyKeys.WPD_DEVICE_TYPE, out deviceType);
            this.Type = (WPD_DEVICE_TYPES)deviceType;

            string deviceManufacturer;
            propertyValues.GetStringValue(ref DevicePropertyKeys.WPD_DEVICE_MANUFACTURER, out deviceManufacturer);
            this.Manufacturer = deviceManufacturer;
        }

        public PortableDeviceFolder GetContents(PortableDeviceFolder parent = null)
        {
            ValidateConnection();
            var root = new PortableDeviceFolder("DEVICE", "DEVICE");
            if (parent != null)
            {
                root = parent;
            }

            IPortableDeviceContent content;
            _device.Content(out content);
            EnumerateContentsOfParent(ref content, root);

            return root;
        }

        public PortableDeviceFolder GetFullContents(PortableDeviceFolder parent = null)
        {
            ValidateConnection();
            var root = new PortableDeviceFolder("DEVICE", "DEVICE");
            if (parent != null)
            {
                root = parent;
            }

            IPortableDeviceContent content;
            _device.Content(out content);
            EnumerateContentsRecursive(ref content, root);

            return root;
        }

        public void DownloadFile(PortableDeviceFile file, string saveToPath)
        {
            IPortableDeviceContent content;
            _device.Content(out content);

            IPortableDeviceResources resources;
            content.Transfer(out resources);

            PortableDeviceApiLib.IStream wpdStream;
            uint optimalTransferSize = 0;

            resources.GetStream(file.Id, ref DevicePropertyKeys.WPD_RESOURCE_DEFAULT, 0, ref optimalTransferSize, out wpdStream);

            var sourceStream = (System.Runtime.InteropServices.ComTypes.IStream)wpdStream;

            var filename = Path.GetFileName(file.Name);
            FileStream targetStream = new FileStream(Path.Combine(saveToPath, filename), FileMode.Create, FileAccess.Write);

            unsafe
            {
                var buffer = new byte[1024];
                int bytesRead;
                do
                {
                    sourceStream.Read(buffer, 1024, new IntPtr(&bytesRead));
                    targetStream.Write(buffer, 0, 1024);
                } while (bytesRead > 0);
                targetStream.Close();
            }
        }

        public void TransferContentToDevice(string fileName,
                                            string parentObjectId)
        {

            IPortableDeviceContent content;
            _device.Content(out content);

            IPortableDeviceValues values =
                GetRequiredPropertiesForContentType(fileName, parentObjectId);

            PortableDeviceApiLib.IStream tempStream;
            uint optimalTransferSizeBytes = 0;
            content.CreateObjectWithPropertiesAndData(
                values,
                out tempStream,
                ref optimalTransferSizeBytes,
                null);

            System.Runtime.InteropServices.ComTypes.IStream targetStream =
                (System.Runtime.InteropServices.ComTypes.IStream)tempStream;

            try
            {
                using (var sourceStream =
                       new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    var buffer = new byte[optimalTransferSizeBytes];
                    int bytesRead;
                    do
                    {
                        bytesRead = sourceStream.Read(
                            buffer, 0, (int)optimalTransferSizeBytes);
                        IntPtr pcbWritten = IntPtr.Zero;
                        if (bytesRead < (int)optimalTransferSizeBytes)
                        {
                            targetStream.Write(buffer, bytesRead, pcbWritten);
                        }
                        else
                        {
                            targetStream.Write(buffer, (int)optimalTransferSizeBytes, pcbWritten);
                        }

                    } while (bytesRead > 0);
                }
                targetStream.Commit(0);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(tempStream);
            }
        }

        private IPortableDeviceValues GetRequiredPropertiesForContentType(
            string fileName,
            string parentObjectId)
        {
            IPortableDeviceValues values =
                new PortableDeviceTypesLib.PortableDeviceValues() as IPortableDeviceValues;

            values.SetStringValue(ref DevicePropertyKeys.WPD_OBJECT_PARENT_ID, parentObjectId);

            FileInfo fileInfo = new FileInfo(fileName);
            values.SetUnsignedLargeIntegerValue(DevicePropertyKeys.WPD_OBJECT_SIZE, (ulong)fileInfo.Length);

            values.SetStringValue(DevicePropertyKeys.WPD_OBJECT_ORIGINAL_FILE_NAME, Path.GetFileName(fileName));

            values.SetStringValue(DevicePropertyKeys.WPD_OBJECT_NAME, Path.GetFileName(fileName));

            values.SetBoolValue(DevicePropertyKeys.WPD_OBJECT_CAN_DELETE, 1);

            return values;
        }

        public override string ToString()
        {
            return $"{this.FriendlyName} - {this.Manufacturer} {this.Model} ({this.Type.ToString()})";
        }

        public PortableDeviceObject GetObject(string parentID, string objectID)
        {

            IPortableDeviceContent content;
            _device.Content(out content);

            // Get the properties of the object
            IPortableDeviceProperties properties;
            content.Properties(out properties);

            if (parentID == null || parentID.Length == 0)
            {
                parentID = DeviceID;
            }

            // Enumerate the items contained by the current object
            IEnumPortableDeviceObjectIDs objectIds;
            content.EnumObjects(0, parentID, null, out objectIds);

            uint fetched = 0;
            do
            {
                string objectId;

                objectIds.Next(1, out objectId, ref fetched);
                if (fetched > 0)
                {
                    if (objectId.Equals(objectID))
                    {

                        PortableDeviceObject deviceObject = WrapObject(properties, objectId);
                        if (deviceObject.GetType() == typeof(PortableDeviceFolder))
                        {
                            EnumerateContentsOfParent(ref content, (PortableDeviceFolder)deviceObject);

                        }
                        return deviceObject;
                    }


                }
            } while (fetched > 0);

            return null;
        }

        public string CreateFolder(string parentPersistentID, string folderName)
        {

            IPortableDeviceContent content;
            _device.Content(out content);

            // Get the properties of the object
            IPortableDeviceProperties properties;
            content.Properties(out properties);

            if (parentPersistentID == null)
            {
                parentPersistentID = DeviceID;
            }

            IPortableDeviceValues createFolderValues = new PortableDeviceTypesLib.PortableDeviceValues() as IPortableDeviceValues;
            createFolderValues.SetStringValue(DevicePropertyKeys.WPD_OBJECT_PARENT_ID, parentPersistentID);
            createFolderValues.SetStringValue(DevicePropertyKeys.WPD_OBJECT_NAME, folderName);
            createFolderValues.SetStringValue(DevicePropertyKeys.WPD_OBJECT_ORIGINAL_FILE_NAME, folderName);
            createFolderValues.SetGuidValue(DevicePropertyKeys.WPD_OBJECT_CONTENT_TYPE, DeviceGUIDS.WPD_CONTENT_TYPE_FOLDER);
            createFolderValues.SetGuidValue(DevicePropertyKeys.WPD_OBJECT_FORMAT, DeviceGUIDS.WPD_OBJECT_FORMAT_PROPERTIES_ONLY);

            string newFolderId = "";
            content.CreateObjectWithPropertiesOnly(createFolderValues, ref newFolderId);

            return newFolderId;
        }

        private static void EnumerateContentsRecursive(ref IPortableDeviceContent content,
                                              PortableDeviceFolder parent)
        {
            // Get the properties of the object
            IPortableDeviceProperties properties;
            content.Properties(out properties);



            // Enumerate the items contained by the current object
            IEnumPortableDeviceObjectIDs objectIds;
            content.EnumObjects(0, parent.Id, null, out objectIds);

            uint fetched = 0;
            do
            {
                string objectId;

                objectIds.Next(1, out objectId, ref fetched);
                if (fetched > 0)
                {
                    var currentObject = WrapObject(properties, objectId);

                    parent.Files.Add(currentObject);

                    if (currentObject is PortableDeviceFolder)
                    {
                        EnumerateContentsRecursive(ref content, (PortableDeviceFolder)currentObject);
                    }
                }
            } while (fetched > 0);
        }

        private static void EnumerateContentsOfParent(ref IPortableDeviceContent content,
                                              PortableDeviceFolder parent)
        {

            // Get the properties of the object
            IPortableDeviceProperties properties;
            content.Properties(out properties);

            // Enumerate the items contained by the current object
            IEnumPortableDeviceObjectIDs objectIds;
            content.EnumObjects(0, parent.Id, null, out objectIds);

            uint fetched = 0;
            do
            {
                string objectId;

                objectIds.Next(1, out objectId, ref fetched);
                if (fetched > 0)
                {
                    var currentObject = WrapObject(properties, objectId);

                    parent.Files.Add(currentObject);

                }
            } while (fetched > 0);
        }

        private static PortableDeviceObject WrapObject(IPortableDeviceProperties properties,
                                                       string objectId)
        {
            IPortableDeviceKeyCollection keys;
            properties.GetSupportedProperties(objectId, out keys);

            IPortableDeviceValues values;
            properties.GetValues(objectId, keys, out values);

            Guid contentType;
            values.GetGuidValue(DevicePropertyKeys.WPD_OBJECT_CONTENT_TYPE, out contentType);

            string uniqueID;
            values.GetStringValue(DevicePropertyKeys.WPD_OBJECT_PERSISTENT_UNIQUE_ID, out uniqueID);

            PortableDeviceObject deviceObject = null;

            if (contentType == DeviceGUIDS.WPD_CONTENT_TYPE_FOLDER || contentType == DeviceGUIDS.WPD_CONTENT_TYPE_FUNCTIONAL_OBJECT)
            {
                string name;
                values.GetStringValue(DevicePropertyKeys.WPD_OBJECT_NAME, out name);
                deviceObject = new PortableDeviceFolder(objectId, name);
            }
            else
            {
                // Get full name which includes file extension:
                var fullName = default(string);
                values.GetStringValue(DevicePropertyKeys.WPD_OBJECT_ORIGINAL_FILE_NAME, out fullName);
                deviceObject = new PortableDeviceFile(objectId, fullName);
            }

            deviceObject.PersistentId = uniqueID;

            return deviceObject;
        }

        #region "DELETE"

        // Source: http://dl.dropbox.com/u/40603470/WPDDeletingContent.zip

        public void DeleteFile(PortableDeviceFile file)
        {
            IPortableDeviceContent content;
            this._device.Content(out content);

            var variant = new PortableDeviceApiLib.tag_inner_PROPVARIANT();
            StringToPropVariant(file.Id, out variant);

            PortableDeviceApiLib.IPortableDevicePropVariantCollection objectIds =
                new PortableDeviceTypesLib.PortableDevicePropVariantCollection()
                as PortableDeviceApiLib.IPortableDevicePropVariantCollection;
            objectIds.Add(variant);

            content.Delete(0, objectIds, null);
        }

        private static void StringToPropVariant(
    string value,
    out PortableDeviceApiLib.tag_inner_PROPVARIANT propvarValue)
        {
            PortableDeviceApiLib.IPortableDeviceValues pValues =
                (PortableDeviceApiLib.IPortableDeviceValues)
                    new PortableDeviceTypesLib.PortableDeviceValuesClass();

            var WPD_OBJECT_ID = new _tagpropertykey();
            WPD_OBJECT_ID.fmtid =
                new Guid(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA,
                         0x8B, 0x60, 0xEE, 0x4A, 0x3C);
            WPD_OBJECT_ID.pid = 2;

            pValues.SetStringValue(ref WPD_OBJECT_ID, value);

            pValues.GetValue(ref WPD_OBJECT_ID, out propvarValue);
        }

        #endregion
    }
}
