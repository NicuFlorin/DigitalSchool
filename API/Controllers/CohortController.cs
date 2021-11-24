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
    public class CohortController : BaseApiController
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly ISchoolRepository schoolRepository;
        private readonly ICohortRepository cohortRepository;
        public CohortController(IMapper mapper, IUserRepository userRepository, ISchoolRepository schoolRepository,ICohortRepository cohortRepository)
        {
            this.cohortRepository = cohortRepository;
            this.schoolRepository = schoolRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpPost("create")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<ActionResult<CohortDto>> CreateCohort(CohortDto cohortDto)
        {
           
            var cohort = new Cohort
            {
             
                Name = cohortDto.Name,
                ContextId = cohortDto.ContextId
            };

            if(await this.cohortRepository.AddCohort(cohort)){
                return Ok(this.mapper.Map<CohortDto>(cohort));
            }
            return BadRequest("Failed to add the cohort");



        }

    }
}