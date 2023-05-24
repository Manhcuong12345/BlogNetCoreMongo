using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_NetCore_MongoDB.Common;
using Project_NetCore_MongoDB.Dto;
using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Services.Interface;
using AutoMapper;

namespace Project_NetCore_MongoDB.Controllers
{
   [Route("api/users")]
    public class AuthsController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AuthsController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        //[Authorize(Policy = "AdminPolicy")]
        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] UsersDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //var userId = HttpContext.User.Claims.First(i => i.Type == "id").Value;
            //if (userId != user.dataId) return BadRequest(new { message = "Invalid Email" });

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var userData = await _usersService.RegisterAsync(user);

            return Ok(userData);
        }

        // POST api/<AuthsController>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthsDto user)
        {
            var userLogin = await _usersService.LoginUser(user.Email);

            if (userLogin == null) return BadRequest(new { message = "Invalid Email" });

            if (!BCrypt.Net.BCrypt.Verify(user.Password, userLogin.Password))
            {
                return BadRequest(new { message = "Invalid Password" });
            }

            if (userLogin != null)
            {
                var token = new JwtTokenBuilder()
                                    .AddSecurityKey(JwtSecurityKey.Create("key-value-token-expires"))
                                    .AddSubject(user.Email)
                                    .AddSubject1(userLogin.Id)
                                    .AddSubject2(user.Email)
                                    .AddIssuer("issuerTest")
                                    .AddAudience("bearerTest")
                                    .AddClaim(userLogin.RolesName.ToString(), "")
                                    .AddExpiry(1)
                                    .Build();

                return Ok(new { jwt = token.Value });

            }
            else
                return Unauthorized($"Unauthorized");
        }
    }
}
