using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Entities.Uploads;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UploadRepository : IUploadRepository
    {
        private readonly IMapper mapper;
        private readonly DataContext context;
        private readonly IStorageService storageService;
        public UploadRepository(IMapper mapper, DataContext context, IStorageService storageService)
        {
            this.storageService = storageService;
            this.context = context;
            this.mapper = mapper;

        }

        public async Task<bool> SubmitAssignment(AssignmentSubmit submit)
        {
            submit.File.Url = await storageService.UploadFile("digital-school-bucket", submit.File);

            var result = this.context.AssignmentSubmit.Add(submit);
            return await this.context.SaveChangesAsync() > 0;


        }


        public async Task<AssignmentDto> UploadAssignment(Assignment assignment)
        {
            if (assignment.Files != null)
            {
                foreach (var file in assignment.Files)
                {
                    file.Url = await storageService.UploadFile("digital-school-bucket", file);
                }
            }
            var result = this.context.Assignment.Add(assignment);
            if (await this.context.SaveChangesAsync() > 0)
            {
                return this.mapper.Map<AssignmentDto>(result.Entity);
            }
            return null;
        }

        public async Task<bool> UploadQuiz(Quiz quiz)
        {

            if (quiz.Questions.Count() > 0)
            {

                foreach (var question in quiz.Questions)
                {
                    if (question.Image != null)
                    {
                        question.Image.Url = await storageService.UploadFile("digital-school-bucket", question.Image);
                    }
                    if (question.shortAnswear != null)
                    {
                        continue;
                    }
                    if (question.Choices == null || question.Choices.Count() == 0)
                    {
                        return false;
                    }
                    int no_correct = 0;
                    foreach (var choice in question.Choices)
                    {
                        if (choice.isCorrect)
                        {
                            no_correct++;
                        }
                        if (no_correct > 1 && !question.hasMultipleAnswears)
                        {
                            return false;
                        }
                    }
                    if (no_correct == 0)
                    {
                        return false;
                    }

                }

                var result = this.context.Quiz.Add(quiz);
                result.Entity.MaximumGrade = result.Entity.Questions.Sum(s => s.Mark);
                return await this.context.SaveChangesAsync() > 0;

            }
            return false;
        }

        public async Task<ResourceDto> UploadResource(Resource resource)
        {
            if (resource.Files != null)
            {
                foreach (var file in resource.Files)
                {
                    file.Url = await storageService.UploadFile("digital-school-bucket", file);
                }
            }
            resource.DateOfUpload = DateTime.Now;
            var result = await this.context.Resource.AddAsync(resource);
            await this.context.SaveChangesAsync();
            return this.mapper.Map<ResourceDto>(resource);
        }

        public async Task<FileDto> GetFile(int id_file)
        {
            var file = await this.context.FileUpload.SingleOrDefaultAsync(u => u.Id == id_file);



            var fileDto = new FileDto
            {
                FileName = file.FileName,
                Type = file.Type,

            };


            return fileDto;
        }

        public async Task<UploadDto> GetUpload(int id_upload)
        {

            var upload = await this.context.Upload
                           .Include(u => u.Files)
                           .SingleOrDefaultAsync(u => u.Id == id_upload);
            switch (upload.Discriminator)
            {
                case "Assignment": return this.mapper.Map<AssignmentDto>(upload);
                case "Quiz": return this.mapper.Map<QuizDto>(upload);
                default: return this.mapper.Map<UploadDto>(upload);
            }




        }
    }
}