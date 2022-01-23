using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Entities.Uploads;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UploadController : BaseApiController
    {
        private readonly IUploadRepository uploadRepository;
        private readonly IMapper mapper;
        private readonly IStorageService storageService;
        public UploadController(IUploadRepository uploadRepository, IMapper mapper, IStorageService storageService)
        {
            this.storageService = storageService;
            this.mapper = mapper;
            this.uploadRepository = uploadRepository;

        }

        [HttpPost("assignment")]
        [Authorize(Policy = "RequireTeacherRole")]
        public async Task<ActionResult<AssignmentDto>> UploadAssignment(AssignmentDto assignmentDto)
        {
            var assignment = this.mapper.Map<Assignment>(assignmentDto);
            try
            {
                var result = await this.uploadRepository.UploadAssignment(assignment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost("quiz")]
        [Authorize(Policy = "RequireTeacherRole")]
        public async Task<ActionResult> UploadQuiz(QuizDto quizDto)
        {
            var quiz = this.mapper.Map<Quiz>(quizDto);
            try
            {
                var result = await this.uploadRepository.UploadQuiz(quiz);
                if (result) return Ok();
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult> SubmitAssignment(AssignmentSubmitDto assignmentSubmitDto)
        {
            //check authorization

            var submit = this.mapper.Map<AssignmentSubmit>(assignmentSubmitDto);
            var result = await this.uploadRepository.SubmitAssignment(submit);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("upload-resource")]
        [Authorize(Policy = "RequireTeacherRole")]
        public async Task<ActionResult<ResourceDto>> UploadResource([FromForm] ResourceDto resourceDto)
        {
            var files = await ClientFiles.UploadFiles(resourceDto.ClientFiles);
            resourceDto.Files = files;
            //chec auth
            var resource = this.mapper.Map<Resource>(resourceDto);


            var result = await this.uploadRepository.UploadResource(resource);
            return result;
        }

        [HttpGet("get-upload/{id_upload}")]
        public async Task<ActionResult<UploadDto>> GetUpload(int id_upload)
        {

            var upload = await this.uploadRepository.GetUpload(id_upload);
            return Ok(upload);
        }

        [HttpGet("get-file/{id_file}")]
        public async Task<IActionResult> GetFiles(int id_file)
        {
            try
            {

                var file = await this.uploadRepository.GetFile(id_file);
                string filePath = await storageService.GetFile(file.FileName);
                if (filePath != null)
                {

                    MemoryStream ms = new MemoryStream(await System.IO.File.ReadAllBytesAsync(filePath));

                    var fileContentResult = new FileStreamResult(ms, file.Type)
                    {
                        FileDownloadName = file.FileName
                    };

                    System.IO.File.Delete(filePath);



                    return fileContentResult;
                }

                //check user authorization
                return BadRequest("Ceva e nul");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

    }
}