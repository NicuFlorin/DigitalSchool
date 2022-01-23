using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using Microsoft.AspNetCore.Http;

namespace API.Helpers
{
    public static class ClientFiles
    {
        public static async Task<ICollection<FileDto>> UploadFiles(ICollection<IFormFile> Files)
        {
            long size = Files.Sum(f => f.Length);
            List<FileDto> result = new List<FileDto>();
            foreach (var formFile in Files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    result.Add(new FileDto { Url = filePath, FileName = formFile.FileName, Type = formFile.ContentType });
                }


            }
            return result;
        }
    }
}