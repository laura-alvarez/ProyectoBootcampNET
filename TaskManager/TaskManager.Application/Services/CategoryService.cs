using AutoMapper;
using TaskManager.Application.Models.Users;
using TaskManager.Application.Services.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryResponseModel>> GetAll()
        {
            var categoryEntity = await _categoryRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryResponseModel>>(categoryEntity); ;
        }

        public async Task<CategoryResponseModel> GetById(int id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);

            return _mapper.Map<CategoryResponseModel>(categoryEntity);
        }
        public Task Add(CategoryRequestModel entity)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(entity);          
            _categoryRepository.AddAsync(categoryEntity);
            return _categoryRepository.SaveChangesAsync();
        }

        public async Task Update(CategoryRequestModel entity, int id)
        {
            CategoryEntity categoryEntityNotFound = await _categoryRepository.GetByIdAsync(id) ?? throw new Exception("El usuario no existe");

            var categoryEntity = _mapper.Map(entity, categoryEntityNotFound);

            await _categoryRepository.UpdateAsync(categoryEntity);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            await _categoryRepository.SaveChangesAsync();
        }
    }
}
