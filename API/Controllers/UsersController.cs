using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using API.Params;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]

    public class UsersController : BaseApiController
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenService tokenService;
        private readonly UserManager<AppUser> userManager;

        private readonly IMapper mapper;
        public UsersController(UserManager<AppUser> userManager,IUserRepository userRepository, IMapper mapper, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers([FromQuery] UserParams userParams)
        {
            userParams.CurrentUserId = User.GetUserId();
            var user = await userRepository.GetMemberAsync(userParams.CurrentUserId);
         

            var users = await this.userRepository.GetMembersAsync(userParams);

            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetUser(int id)
        {
            var user = await this.userRepository.GetMemberAsync(id);


            return Ok(user);
        }
        [HttpPost("add-user")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<ActionResult<MemberDto>> AddUser(RegisterDto registerDto)
        {
            var id = User.GetUserId();
            var user = await userRepository.GetMemberAsync(id);

            if (await UserExists(registerDto.Username))
            {
                return BadRequest("Username is taken");
            }




         
            var userToAdd = this.mapper.Map<AppUser>(registerDto);

            var result = await this.userManager.CreateAsync(userToAdd, registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await this.userManager.AddToRolesAsync(userToAdd, registerDto.Roles);
            if (!roleResult.Succeeded) return BadRequest(result.Errors);
            

            return new MemberDto
            {
                Username = registerDto.Username,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Id = userToAdd.Id,
            };
        }
        private async Task<bool> UserExists(string username)
        {
            return await this.userManager.Users.AnyAsync(user => user.UserName.ToLower() == username.ToLower());
        }
    }
}