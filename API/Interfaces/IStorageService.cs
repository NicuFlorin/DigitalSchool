using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities.Uploads;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface IStorageService
    {
        Task<string> UploadFile(string bucketName, FileUpload fileDto);
        Task<string> GetFile(string fileName);
    }
}