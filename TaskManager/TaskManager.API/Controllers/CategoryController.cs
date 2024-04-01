using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Models.Users;
using TaskManager.Application.Services.Interfaces;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Obtiene un listado de categorías
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCategories")]
        public Task<IEnumerable<CategoryResponseModel>> GetAllCategories()
        {
            return _categoryService.GetAll();
        }

        /// <summary>
        /// Obtiene la información de una categoría
        /// </summary>
        /// <param name="idCategory"></param>
        /// <returns></returns>
        [HttpGet("GetCategory")]
        public async Task<CategoryResponseModel> GetCategory(int idCategory)
        {
            return await _categoryService.GetById(idCategory);
        }

        /// <summary>
        /// Agrega una categoría
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost("AddCategory")]
        public async Task AddCategory(CategoryRequestModel category)
        {
            await _categoryService.Add(category);
        }

        /// <summary>
        /// Actualiza una categoría
        /// </summary>
        /// <param name="category"></param>
        /// <param name="idCategory"></param>
        /// <returns></returns>
        [HttpPut("UpdateCategory")]
        public async Task UpdateCategory(CategoryRequestModel category, int idCategory)
        {
            await _categoryService.Update(category, idCategory);
        }


        /// <summary>
        /// Elimina una categoría
        /// </summary>
        /// <param name="idCategory"></param>
        /// <returns></returns>
        [HttpDelete("DeleteCategory")]
        public async Task DeleteCategory(int idCategory)
        {
            await _categoryService.Delete(idCategory);
        }
    }
}
