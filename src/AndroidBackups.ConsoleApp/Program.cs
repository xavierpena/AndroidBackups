using PortableDevices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidBackups.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var deviceIds = PortableDeviceClient.GetAllDeviceIds();
                var deviceId = deviceIds.Values.First();
                var portableDeviceClient = new PortableDeviceClient(deviceId);

                ProcessDeviceBackup(portableDeviceClient);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected exception:\r\n{ex.ToString()}");
            }
        }

        private static void ProcessDeviceBackup(PortableDeviceClient portableDeviceClient)
        {
            Console.WriteLine($"Loading device contents ...");
            portableDeviceClient.LoadDeviceContents();

            var sourceFolderFullPaths = new string[] {
                @"Internal storage\WhatsApp\Media\WhatsApp Images",
                @"Internal storage\WhatsApp\Media\WhatsApp Video",
                @"Internal storage\DCIM\Camera"
            };

            var baseDestinationFolder = @"C:\Users\xavierpenya\Desktop\CopyTest";

            foreach (var sourceFolder in sourceFolderFullPaths)
            {
                var folderName = sourceFolder.Split('\\').Last();
                Console.WriteLine($"Processing folder '{folderName}' ...");
                var mtpFolder = portableDeviceClient.GetSubFolder(sourceFolder);
                var destinationFolderFullPath = Path.Combine(baseDestinationFolder, folderName);
                TryRecreateFolder(destinationFolderFullPath);
                portableDeviceClient.CopyFolder(mtpFolder, destinationFolderFullPath);
            }
            Console.WriteLine("Done");
        }

        private static void TryRecreateFolder(string destinationFolderFullPath)
        {
            if (Directory.Exists(destinationFolderFullPath))
                Directory.Delete(destinationFolderFullPath, recursive: true);
            Directory.CreateDirectory(destinationFolderFullPath);
        }
    }
}
