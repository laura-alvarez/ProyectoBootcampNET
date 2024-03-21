using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Models.Users;
using TaskManager.Application.Services.Interfaces;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllCategories")]
        public Task<IEnumerable<CategoryResponseModel>> GetAllCategories()
        {
            return _categoryService.GetAll();
        }

        [HttpPut("AddCategory")]
        public async Task AddTask(CategoryRequestModel category)
        {
            await _categoryService.Add(category);
        }
    }
}
