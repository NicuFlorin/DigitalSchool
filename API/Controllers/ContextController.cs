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
    public class ContextController : BaseApiController
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly ICourseRepository courseRepository;
        private readonly IContextRepository contextRepository;
        public ContextController(IMapper mapper, IUserRepository userRepository, ICourseRepository courseRepository,IContextRepository contextRepository)
        {
            this.contextRepository = contextRepository;
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

        
        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<Context>>> GetContexts(){
            var id = User.GetUserId();
            var user = await userRepository.GetMemberAsync(id);

            var contexts = await this.contextRepository.GetContexts();
            return Ok(contexts);
        }
    }
}