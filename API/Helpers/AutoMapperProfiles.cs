using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Entities.Uploads;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();
            CreateMap<AppUserRole, RoleDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.TeacherFirstName,
                           opt => opt.MapFrom(src => src.Teacher.FirstName))
                .ForMember(dest => dest.TeacherLastName,
                           opt => opt.MapFrom(src => src.Teacher.LastName))
                .ForMember(dest => dest.CohortName, opt => opt.MapFrom(src => src.Cohort.Name));
            CreateMap<Section, SectionDto>();

            CreateMap<RegisterDto, AppUser>();
            CreateMap<Cohort, CohortDto>()
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Students.Count(x => x.CohortId == src.Id)));
            CreateMap<Context, ContextDto>();
            CreateMap<StudentEnrollment, StudentDto>()
                    .ForMember(dest => dest.MemberDto, opt => opt.MapFrom(src => src.AppUser));
            CreateMap<AssignmentDto, Assignment>();
            CreateMap<FileDto, FileUpload>();
            CreateMap<Assignment, AssignmentDto>();
            CreateMap<FileUpload, FileDto>();

            CreateMap<Quiz, QuizDto>();
            CreateMap<QuizDto, Quiz>();
            CreateMap<QuestionDto, Question>();
            CreateMap<ChoiceDto, Choice>();

            CreateMap<QuizSubmit, QuizSubmitDto>()
                    .ForMember(dest => dest.CurrentQuestion,
                    opt => opt.MapFrom(src => src.Answears.ElementAt(src.IndexCurrentQuestion)))
                    .ForMember(dest => dest.TimeLeft,
                    opt => opt.MapFrom(src => src.DateOpened.CalculateTimeLeft(src.Quiz.TimeLimit)));

            CreateMap<Resource, ResourceDto>()
                .ForMember(dest => dest.Files,
                opt => opt.MapFrom(src => src.Files));
            CreateMap<ResourceDto, Resource>();
            CreateMap<Upload,UploadDto>();
        }
    }
}