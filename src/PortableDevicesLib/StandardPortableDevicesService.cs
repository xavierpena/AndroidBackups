using System;
using PortableDevicesLib.Domain;
using PortableDeviceApiLib;
using System.Collections.Generic;

namespace PortableDevicesLib
{

    public class StandardPortableDevicesService : PortableDevicesService
    {
        private PortableDeviceManager portableDeviceManager = new PortableDeviceManagerClass();
        
        public StandardPortableDevicesService()
        {
            
        }
        
        public IList<Domain.PortableDevice> Devices {
            get {

                portableDeviceManager.RefreshDeviceList();  
                
                uint numberOfDevices = 0;
                portableDeviceManager.GetDevices(null, ref numberOfDevices);

                if (numberOfDevices == 0)
                {
                    return new List<Domain.PortableDevice>();
                }
                
                string[] deviceIds = new string[numberOfDevices];
                portableDeviceManager.GetDevices(deviceIds, ref numberOfDevices);

                List<Domain.PortableDevice> devices = new List<Domain.PortableDevice>();
                foreach(string deviceId in deviceIds) {
                    devices.Add(new Domain.PortableDevice(deviceId));
                }
                
                return devices;
            }
        }
       
    }
}
