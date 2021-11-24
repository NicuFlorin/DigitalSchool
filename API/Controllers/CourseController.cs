using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CourseController : BaseApiController
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly ISchoolRepository schoolRepository;
        private readonly ICourseRepository courseRepository;
        public CourseController(IMapper mapper, IUserRepository userRepository, ISchoolRepository schoolRepository, ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
            this.schoolRepository = schoolRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("addCategory")]
        public async Task<ActionResult> AddCategory(ContextDto contextDto)
        {
            var id = User.GetUserId();
            var user = await userRepository.GetMemberAsync(id);
            var school = await schoolRepository.GetSchool(user.SchoolId);

            var parent = await courseRepository.GetCategory(contextDto.ParentId);

            var Context = new Context
            {
                School = school,
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

            if (await courseRepository.AddCourse(courseDto))
            {
                return Ok(courseDto);
            }
            return BadRequest("Failed to add a Category");
        }
    }
}