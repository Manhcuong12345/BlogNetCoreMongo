using Microsoft.AspNetCore.Mvc;
using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Services;
using Project_NetCore_MongoDB.Dto;
using Project_NetCore_MongoDB.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Project_NetCore_MongoDB.Common;
using Newtonsoft.Json;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_NetCore_MongoDB.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categorieService;
        private readonly IUsersService _sersvice;
        public CategoriesController(ICategoriesService categorieService, IUsersService sersvice)
        {
            _categorieService = categorieService;
            _sersvice = sersvice;
        }

        // GET: api/<CountriesController>
        [Authorize(Policy= "AdminPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categorieService.GetAllAsync());
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var categories = await _categorieService.GetByIdAsync(id);

            if (categories == null)
            {
                return NotFound($"Categories is not found!");
            }

            var categorieDto = new CategoriesDto
            {
                Id = categories.Id,
                Name = categories.Name,
                Slug = categories.Slug
            };

          
            return Ok(categorieDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categories categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _categorieService.CreateAsync(categories);
            return CreatedAtAction(nameof(Get), new { id = categories.Id }, categories);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Categories categories)
        {
            var data = await _categorieService.GetByIdAsync(id);

            if (data == null)
            {
                return NotFound($"Categories is not found!");
            }

            await _categorieService.UpdateAsync(id, categories);

            return CreatedAtAction(nameof(Get), new { id = categories.Id }, categories);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var categories = await _categorieService.GetByIdAsync(id);

            if (categories == null)
            {
                return NotFound($"Categories is not found!");
            }

            await _categorieService.DeleteAsync(id).ConfigureAwait(false);

            return Ok($"Categories with Id = {id} is deleted");
        }
    }
}

