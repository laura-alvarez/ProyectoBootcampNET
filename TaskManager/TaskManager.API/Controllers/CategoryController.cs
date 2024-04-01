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

        [HttpGet("GetCategory")]
        public async Task<CategoryResponseModel> GetCategory(int idCategory)
        {
            return await _categoryService.GetById(idCategory);
        }

        [HttpPost("AddCategory")]
        public async Task AddCategory(CategoryRequestModel category)
        {
            await _categoryService.Add(category);
        }

        [HttpPut("UpdateCategory")]
        public async Task UpdateCategory(CategoryRequestModel category, int idCategory)
        {
            await _categoryService.Update(category, idCategory);
        }



        [HttpDelete("DeleteCategory")]
        public async Task DeleteCategory(int idCategory)
        {
            await _categoryService.Delete(idCategory);
        }
    }
}
