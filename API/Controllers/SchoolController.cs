using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SchoolController : BaseApiController
    {
        private readonly ISchoolRepository schoolRepository;
        public SchoolController(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;

        }

        [HttpPost("register")]
        public async Task<ActionResult<int>> register()
        {
            var school = new SchoolDto
            {
                Name = "Your school"
            };

            int idSchool = await schoolRepository.AddSchool(school);
            if (idSchool != -1)
                return Ok(idSchool);
            else return BadRequest("DB error");
        }





    }
}