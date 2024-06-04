using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppUserRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;


        public AccountController(UserManager<AppUser> userManager,
            RoleManager<AppUserRole> roleManager,
            IConfiguration configuration,
            SignInManager<AppUser> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        //auth/create
        [HttpPost("register")]
        [Authorize(Roles = nameof(ApplicationRoleTypes.Admin))]
        public async Task<ActionResult<UserDto>> RegisterUserAsync([FromBody] UserRegisterDto inboundUser)
        {
            try
            {
                if (await _userManager.Users.AnyAsync(x => x.UserName == inboundUser.Username))
                {
                    ModelState.AddModelError("username", "Username is already taken.");
                    return ValidationProblem();
                }

                if (!string.IsNullOrWhiteSpace(inboundUser.UserRole))
                {
                    if (await _roleManager.RoleExistsAsync(inboundUser.UserRole))
                    {
                        ModelState.AddModelError("role", "Role is not exists.");
                        return ValidationProblem();
                    }
                }
                else
                {
                    inboundUser.UserRole = nameof(ApplicationRoleTypes.User);
                }

                var user = new AppUser { UserName = inboundUser.Username, DisplayName = inboundUser.DisplayName, Email = inboundUser.Email };

                var result = await _userManager.CreateAsync(user, inboundUser.Password);
                await _userManager.AddToRoleAsync(user, inboundUser.UserRole);

                var errors = result.Errors.Select(e => e.Description);

                if (result.Succeeded)
                {
                    return Ok(await CreateUserObjectAsync(user));
                }
                else
                {
                    return BadRequest(errors);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //auth/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> LoginAync([FromBody] UserLoginDto userInfo)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == userInfo.Username || x.UserName == userInfo.Username);
                if (user == null)
                {
                    return Unauthorized();
                }

                var result = await _userManager.CheckPasswordAsync(user, userInfo.Password);


                if (result)
                {
                    return Ok(await CreateUserObjectAsync(user));
                }
                else
                {
                    return BadRequest("Email or password invalid!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private async Task<UserDto> CreateUserObjectAsync(AppUser user)
        {
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Token = await _tokenService.CreateTokenAsync(user),
                Username = user.UserName
            };
        }
    }
}