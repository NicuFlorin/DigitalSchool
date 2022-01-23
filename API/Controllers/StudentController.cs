using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class StudentController : BaseApiController
    {
        private readonly IMapper mapper;
        private readonly IStudentRepository studentRepository;
        public StudentController(IMapper mapper, IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;

        }

        [HttpGet("{id_cohort}")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents(int id_cohort)
        {
            var students = await studentRepository.GetStudents(id_cohort);
            return Ok(students);
        }
        [HttpGet("potential-users/{id_cohort}")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetPotentialUsers(int id_cohort)
        {
            var users = await studentRepository.GetPotentialUsers(id_cohort);
            return Ok(users);
        }

        [HttpPost("assign")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<ActionResult> AssignStudents(List<StudentDto> studentsDto)
        {
            List<StudentEnrollment> students = new List<StudentEnrollment>();

            foreach (StudentDto studentDto in studentsDto)
            {
                students.Add(new StudentEnrollment { AppUserId = studentDto.MemberDto.Id, CohortId = studentDto.CohortId });
            }

            var res = await studentRepository.AssignStudents(students);

            if (res)
            {
                return Ok();
            }

            else return BadRequest();


        }
        [HttpPost("remove")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<ActionResult> DeleteStudents(List<StudentDto> studentsDto)
        {
            List<StudentEnrollment> students = new List<StudentEnrollment>();
            foreach (StudentDto studentDto in studentsDto)
            {
                students.Add(new StudentEnrollment { AppUserId = studentDto.MemberDto.Id, CohortId = studentDto.CohortId });
            }
            var res = await studentRepository.RemoveStudents(students);
            if (res)
            {
                return Ok();
            }
            return BadRequest();
        }
    }


}