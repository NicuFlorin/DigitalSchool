using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Entities.Uploads;

namespace API.Interfaces
{
    public interface IUploadRepository
    {
        Task<AssignmentDto> UploadAssignment(Assignment assignment);
        Task<bool> UploadQuiz(Quiz quiz);
        Task<bool> SubmitAssignment(AssignmentSubmit submit);

        Task<ResourceDto> UploadResource(Resource resource);
        Task<FileDto> GetFile(int id_upload);

        Task<UploadDto> GetUpload(int id_upload);


    }
}