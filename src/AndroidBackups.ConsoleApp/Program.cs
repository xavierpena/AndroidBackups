using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortableDevicesLib;
using PortableDevicesLib.Domain;

namespace AndroidBackups.ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Get the only connected MTP device:                
                var service = new StandardPortableDevicesService();
                var devices = service.Devices;
                var device = devices.Single();                               

                // Start the backup:
                ProcessDeviceBackup(device);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected exception:\r\n{ex.ToString()}");
            }
        }

        private static void ProcessDeviceBackup(PortableDevice device)
        {
            // ===
            // CONFIGURATION:
            var sourceFolderFullPaths = new string[] {
                @"Internal storage\WhatsApp\Media\WhatsApp Images",
                @"Internal storage\WhatsApp\Media\WhatsApp Video",
                @"Internal storage\DCIM\Camera"
            };

            var baseDestinationFolder = @"C:\Users\xavier.pena\Desktop\" + DateTime.Now.ToString("yyyy-MM-dd") + " Backup";

            // ===
            // PROCESSING:
            var portableDeviceService = new PortableDeviceService(device);

            Console.WriteLine($"Loading device contents ...");
            portableDeviceService.LoadDeviceContents();

            Console.WriteLine("Copying ...");
            //CopyToWindows(portableDeviceService, sourceFolderFullPaths, baseDestinationFolder);

            Console.WriteLine("Deleting ...");
            DeleteFromAndroid(portableDeviceService, sourceFolderFullPaths, baseDestinationFolder);

            Console.WriteLine("Done");
        }

        private static void CopyToWindows(PortableDeviceService portableDeviceService, string[] sourceFolderFullPaths, string baseDestinationFolder)
        {
            foreach (var sourceFolder in sourceFolderFullPaths)
            {
                var folderName = sourceFolder.Split('\\').Last();
                Console.WriteLine($"Processing folder '{folderName}' ...");
                var mtpFolder = portableDeviceService.GetSubFolder(sourceFolder);
                var destinationFolderFullPath = Path.Combine(baseDestinationFolder, folderName);
                TryRecreateFolder(destinationFolderFullPath);
                portableDeviceService.CopyFolder(mtpFolder, destinationFolderFullPath);
            }
        }

        private static void DeleteFromAndroid(PortableDeviceService portableDeviceService, string[] sourceFolderFullPaths, string baseDestinationFolder)
        {
            foreach (var sourceFolder in sourceFolderFullPaths)
            {
                var folderName = sourceFolder.Split('\\').Last();
                Console.WriteLine($"Processing folder '{folderName}' ...");
                var mtpFolder = portableDeviceService.GetSubFolder(sourceFolder);
                portableDeviceService.DeleteFilesInFolder(mtpFolder, recursive: true);
            }
        }

        private static void TryRecreateFolder(string destinationFolderFullPath)
        {
            if (Directory.Exists(destinationFolderFullPath))
                Directory.Delete(destinationFolderFullPath, recursive: true);
            Directory.CreateDirectory(destinationFolderFullPath);
        }
    }
}
