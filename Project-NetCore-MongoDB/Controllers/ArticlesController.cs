using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_NetCore_MongoDB.Dto;
using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Services;
using Project_NetCore_MongoDB.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_NetCore_MongoDB.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticlesService _articlesService;
        private readonly IUsersService _usersService;
        private readonly ICategoriesService _categoriesService;
        private readonly IMapper _mapper;
        // GET: api/<AuthsController>

        public ArticlesController(IArticlesService articlesService, IUsersService usersService, ICategoriesService categoriesService, IMapper mapper)
        {
            _articlesService = articlesService;
            _usersService = usersService;
            _categoriesService = categoriesService;
            _mapper = mapper;
        }
        // GET: api/<ArticlesController>
        //[Authorize(Policy = "UserPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _articlesService.GetAllAsync());
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var article = await _articlesService.GetByIdAsync(id);

            if (article == null)
            {
                return NotFound($"Article is not found!");
            }

            article.Users = await _usersService.GetByIdAsync(article.AuthorId);
            article.Categories = await _categoriesService.GetByIdAsync(article.CategoryId);

            return Ok(article);
        }

        //[Authorize(Policy = "UserPolicy")]
        [HttpPost]
        public async Task<IActionResult> Create(ArticlesDto articles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //lay _id tu token khi user do dang nhap
            var userId = HttpContext.User.Claims.First(i => i.Type == "id").Value;
       
            //check kiem tra _id cua user va authorId khi nhap gia tri tao, neu khong khop tra ve loi
            if(userId == null)
            {
                return BadRequest(new {message = "Not authorized to create this articles"});
            }

            articles.AuthorId = userId;
            var articlesData = await _articlesService.CreateAsync(articles);

            return CreatedAtAction(nameof(Get), new { id = articlesData.Id }, articlesData);
        }

        //[Authorize(Policy = "UserPolicy")]
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, ArticlesDto articles)
        {
            var data = await _articlesService.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound($"Articles is not found!");
            }

            var userIdToken = HttpContext.User.Claims.First(i => i.Type == "id").Value;
            //check Id author in artiles vs id token login user. If worng then error. True continue
            if (userIdToken != data.AuthorId)
            {
                return BadRequest(new { message = "Not authorized to update this articles" });
            }
       
            await _articlesService.UpdateAsync(id, articles);

            return CreatedAtAction(nameof(Get), new { id = articles.Id }, articles);
        }

        //[Authorize(Policy = "UserPolicy")]
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var articles = await _articlesService.GetByIdAsync(id);

            if (articles == null)
            {
                return NotFound($"Articles is not found!");
            }

            var userIdToken = HttpContext.User.Claims.First(i => i.Type == "id").Value;
            //check Id author in artiles vs id token login user. If worng then error. True continue
            if (userIdToken != articles.AuthorId)
            {
                return BadRequest(new { message = "Not authorized to delete this articles" });
            }

            await _articlesService.DeleteAsync(id).ConfigureAwait(false);

            return Ok($"Articles with Id = {id} is deleted");
        }
    }
}
