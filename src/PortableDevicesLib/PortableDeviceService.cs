using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableDevicesLib.Domain
{

    /// <summary>
    /// Xavier Peña, 2016-10-07
    /// </summary>
    public class PortableDeviceService
    {
        private PortableDevice _device;
        private PortableDeviceFolder _deviceContents;
        public PortableDeviceService(PortableDevice device)
        {
            _device = device;
        }
        
        /// <summary>
        /// This function may take a while to complete. It retrieves all the file structure from the device.
        /// </summary>
        public void LoadDeviceContents()
        {
            _device.Connect();
            _deviceContents = _device.GetFullContents();
            _device.Disconnect();
        }

        /// <summary>
        /// Navigates to a subfolder defined by a string path, and returns the corresponding PortableDeviceFolder.
        /// </summary>
        /// <param name="folderPath">Chain of folders sepparated by "\": "folder1\folder2\...\folderN"</param>
        /// <returns></returns>
        public PortableDeviceFolder GetSubFolder(string folderPath)
            => GetSubFolder(_deviceContents, folderPath);

        /// <summary>
        /// Navigates to a subfolder defined by a string path, and returns the corresponding PortableDeviceFolder.
        /// </summary>
        /// <param name="rootPortableDeviceFolder">Current folder (iterative processing)</param>
        /// <param name="folderPath">Chain of folders sepparated by "\": "folder1\folder2\...\folderN"</param>
        /// <returns></returns>
        public PortableDeviceFolder GetSubFolder(PortableDeviceFolder rootPortableDeviceFolder, string folderPath)
        {
            var elements = folderPath.Split('\\');
            var nextFolderName = elements.First();
            var nextFolderList = rootPortableDeviceFolder.Files
                .Where(x => x.Name == nextFolderName && IsFolder(x))
                .Select(x => (PortableDeviceFolder)x)
                .ToList();

            if (nextFolderList.Count == 0)
                throw new Exception($"Part of the path was not found: '{nextFolderName}'");
            else if (nextFolderList.Count > 1)
                throw new Exception($"Two or more folders have the same name: '{nextFolderName}'");

            var nextFolder = nextFolderList.Single();

            if(elements.Length == 1)
            {
                // Folder was reached:
                return nextFolder;
            }
            else
            {
                // Keep searching recursively:
                var nextPath = string.Join("\\", elements.Skip(1));
                return GetSubFolder(nextFolder, nextPath);
            }            
        }

        private bool IsFolder(PortableDeviceObject portableDeviceObject)
            => portableDeviceObject.GetType().Name == "PortableDeviceFolder";

        public void CopyFolder(PortableDeviceFolder sourceDeviceFolder, string destinationWindowsFolderPath)
        {
            var directoryInfo = new DirectoryInfo(destinationWindowsFolderPath);
            if (!directoryInfo.Exists)
                directoryInfo.Create();

            var portableDeviceObjects = sourceDeviceFolder.Files;
            foreach(var portableDeviceObject in portableDeviceObjects)
            {
                if(IsFolder(portableDeviceObject))
                {
                    var folder = (PortableDeviceFolder)portableDeviceObject;
                    var newPath = Path.Combine(destinationWindowsFolderPath, folder.Name);
                    CopyFolder( folder, newPath);                
                }
                else
                {
                    var file = (PortableDeviceFile)portableDeviceObject;
                    _device.Connect();
                    _device.DownloadFile(file, destinationWindowsFolderPath);
                    _device.Disconnect();
                }
            }
        }

    }
}
