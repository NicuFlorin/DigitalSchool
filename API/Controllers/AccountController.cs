using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IMapper mapper;
       

        private readonly ITokenService tokenService;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
        {
          
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;

        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username))
            {
                return BadRequest("Username is taken");
            }

            

            var user = this.mapper.Map<AppUser>(registerDto);

            user.UserName = registerDto.Username.ToLower();
           

            var result = await this.userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await this.userManager.AddToRolesAsync(user, registerDto.Roles);
            if (!roleResult.Succeeded) return BadRequest(result.Errors);


            return new UserDto
            {
                Username = registerDto.Username,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Id = user.Id,
                Token = await this.tokenService.CreateToken(user)
            };


        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> login(LoginDto loginDto)
        {
            var user = await this.userManager.Users.SingleOrDefaultAsync(user => user.UserName == loginDto.Username);

            if (user == null)
            {
                return BadRequest("Username or password is invalid!");
            }

            var result = await this.signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized();

            var roles = await this.userManager.GetRolesAsync(user);

            return new UserDto
            {
                Id = user.Id,
                Username = loginDto.Username,
                Token = await tokenService.CreateToken(user),
                Roles = roles
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await this.userManager.Users.AnyAsync(user => user.UserName.ToLower() == username.ToLower());
        }
    }
}