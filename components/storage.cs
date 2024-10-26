using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace trashure.components
{
    internal class storage
    {
        private static string connectionString = App.Configuration.GetConnectionString("AZURE_STORAGE");
        private static string containerName = "images";
        public static async Task<string> UploadImage(string imagePath)
        {
            string imageName = Path.GetFileName(imagePath);

            var blobServiceClient = new BlobServiceClient(connectionString);

            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync();

            var blobClient = containerClient.GetBlobClient(imageName);

            using (var fs = File.OpenRead(imagePath))
            {
                await blobClient.UploadAsync(fs, true);
                fs.Close();
            }

            return blobClient.Uri.ToString();
        }
    }
}
