using Dashboard_api.Models;
using Dashboard_api.Services;
using Microsoft.AspNetCore.Mvc;
namespace Dashboard_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GEt:api/Category
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Category category)
        {
            await _categoryService.CreateAsyncCategory(category);
            return Ok(category);
        }
    }

}