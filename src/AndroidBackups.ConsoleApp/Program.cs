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
                // ===
                // CONFIGURATION:
                var sourceFolderFullPaths = new string[] {
                    @"Internal storage\WhatsApp\Media\WhatsApp Images",
                    @"Internal storage\WhatsApp\Media\WhatsApp Video",
                    @"Internal storage\DCIM\Camera"
                };
                var baseDestinationFolder = @"C:\Users\xavier.pena\Desktop\" + DateTime.Now.ToString("yyyy-MM-dd") + " Backup";

                // Start the backup:
                var portableDeviceService = GetMTPPortableDeviceService();
                ProcessDeviceBackup(portableDeviceService, sourceFolderFullPaths, baseDestinationFolder);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected exception:\r\n{ex.ToString()}");
            }
        }

        private static PortableDeviceService GetMTPPortableDeviceService()
        {
            // Get the only connected MTP device:                
            var service = new StandardPortableDevicesService();
            var devices = service.Devices;
            var device = devices.Single();
            var portableDeviceService = new PortableDeviceService(device);

            return portableDeviceService;
        }

        private static void ProcessDeviceBackup(PortableDeviceService portableDeviceService, string[] sourceFolderFullPaths, string baseDestinationFolder)
        {           
            Console.WriteLine($"Loading device contents ...");
            portableDeviceService.LoadDeviceContents();

            Console.WriteLine("Copying ...");
            CopyToWindows(portableDeviceService, sourceFolderFullPaths, baseDestinationFolder);

            Console.WriteLine("If you want to delete all copied files from the source, press any key ...");
            Console.ReadKey();

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
