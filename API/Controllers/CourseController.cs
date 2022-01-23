using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CourseController : BaseApiController
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IStorageService storageService;

        private readonly ICourseRepository courseRepository;
        public CourseController(IMapper mapper, IUserRepository userRepository,
                 ICourseRepository courseRepository, IStudentRepository studentRepository,
                IStorageService storageService)
        {
            this.storageService = storageService;
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;

            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("addCategory")]
        public async Task<ActionResult> AddCategory(ContextDto contextDto)
        {
            var id = User.GetUserId();
            var user = await userRepository.GetMemberAsync(id);


            var parent = await courseRepository.GetCategory(contextDto.ParentId);

            var Context = new Context
            {

                Name = contextDto.Name,
                Parent = parent
            };
            if (await courseRepository.AddCategory(Context))
            {
                return Ok(this.mapper.Map<ContextDto>(Context));
            }
            return BadRequest("Failed to add a Category");
        }



        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("addCourse")]
        public async Task<ActionResult> AddCourse(CourseDto courseDto)
        {
            if (DateTime.Compare(courseDto.DateStart, courseDto.DateStart) > 0)
            {
                return BadRequest("The dates are in the wrong order");
            }



            if (await courseRepository.AddCourse(courseDto))
            {
                return Ok(courseDto);
            }
            return BadRequest("Failed to add a Category");
        }

        [HttpGet("{id_course}")]
        public async Task<ActionResult<CourseDto>> GetCourseById(int id_course)
        {
            var course = await courseRepository.GetCourseById(id_course);

            if (course != null)
            {
                ;
                if (!await isAuthorized(course))
                {
                    return Unauthorized();
                }
                return Ok(course);
            }
            else return NotFound("not found");
        }
        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAll()
        {
            int id_user = User.GetUserId();
            if (User.IsInRole("Admin"))
            {
                return Ok(await this.courseRepository.GetAllForAdmin());
            }
            if (User.IsInRole("Teacher"))
            {
                return Ok(await this.courseRepository.GetAllForTeacher(id_user));
            }
            if (User.IsInRole("Student"))
            {
                return Ok(await this.courseRepository.GetAllForStudent(id_user));
            }
            return BadRequest("I dont know who you are");
        }
        [HttpGet("get-by-id/{id_course}")]
        public async Task<ActionResult<CourseDto>> GetCourseByID(int id_course)
        {
            var course = await this.courseRepository.GetCourseById(id_course);
            if (course != null)
            {
                return Ok(course);
            }
            return BadRequest();
        }

        private async Task<bool> isAuthorized(CourseDto course)
        {
            if (User.IsInRole("Admin"))
            {
                return true;
            }
            if (User.IsInRole("Student"))
            {
                var studentEnrollments = await studentRepository.GetStudentEnrollmentsById(User.GetUserId());
                foreach (StudentDto studentDto in studentEnrollments)
                {
                    if (studentDto.CohortId == course.Id)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        // [HttpPost("test-file")]
        // public async Task<ActionResult> TestUploadFile(FileDto fileDto)
        // {

        //     storageService.UploadFile("digital-school-bucket", fileDto);

        //     return Ok();

        // }



    }

}