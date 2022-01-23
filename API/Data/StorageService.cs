using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities.Uploads;
using API.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Mvc;

namespace API.Data
{
    public class StorageService : IStorageService
    {
        StorageClient storage;
        ParallelOptions parallelOptions;

        public StorageService()
        {
            var credential = GoogleCredential.GetApplicationDefault();
            storage = StorageClient.Create(credential);
            parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = 2 * Environment.ProcessorCount;

        }

        public async Task<string> UploadFile(string bucketName, FileUpload fileDto)
        {

            using var fileStream = File.OpenRead(fileDto.Url);

            var result = await storage.UploadObjectAsync(bucketName, fileDto.FileName, null, fileStream);

            return result.MediaLink;

        }
        public async Task<string> GetFile(string fileName)
        {
            try
            {

                var filePath = Path.GetTempFileName();

                using (var stream = System.IO.File.Create(filePath))
                {
                    await storage.DownloadObjectAsync("digital-school-bucket", fileName,stream);
                    return filePath;
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}