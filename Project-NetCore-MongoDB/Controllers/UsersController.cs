using Microsoft.AspNetCore.Mvc;
using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Repository.Interface;
using Project_NetCore_MongoDB.Common;
using Project_NetCore_MongoDB.Repository;
using Project_NetCore_MongoDB.Dto;
using System.Security.Claims;
using Project_NetCore_MongoDB.Services.Interface;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_NetCore_MongoDB.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        // GET: api/<AuthsController>

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        //[Authorize(Policy = "AdminPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _usersService.GetAllAsync());
        }

        [Authorize(Policy = "AdminPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] Users user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var userData = await _usersService.CreateAsync(user);

            return Ok(userData);
        }

        //[Authorize(Policy = "AdminPolicy")]
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var users = await _usersService.GetByIdAsync(id).ConfigureAwait(false);

            if (users == null)
            {
                return NotFound($"User is not found!");
            }

            var usersDto = new UsersDto
            {
                Id = users.Id,
                Name = users.Name,
                Email = users.Email,
                Address = users.Address,
                Phone = users.Phone
            };


            return Ok(usersDto);
        }


        //[Authorize(Policy = "AdminPolicy")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Users users)
        {
            var dataId = await _usersService.GetByIdAsync(id).ConfigureAwait(false);

            if (dataId == null)
            {
                return NotFound($"User is not found!");
            }

            await _usersService.UpdateAsync(id, users);

            return CreatedAtAction(nameof(Get), new { id = users.Id }, users);
        }

        //[Authorize(Policy = "AdminPolicy")]
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(string id)
        {
            var users = await _usersService.GetByIdAsync(id).ConfigureAwait(false);

            if(users == null) return NotFound($"User is not found!");

            await _usersService.DeleteAsync(id).ConfigureAwait(false);

            return Ok($"User with Id = {id} is deleted");
        }



    }
}