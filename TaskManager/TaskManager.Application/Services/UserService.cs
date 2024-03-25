using AutoMapper;
using TaskManager.Application.Models.Users;
using TaskManager.Application.Services.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponseModel>> GetAll()
        {
            var userEntity = await _userRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<UserResponseModel>>(userEntity); ;
        }

        public async Task<UserResponseModel> GetById(int id)
        {
            var userEntity = await Task.Run(() => _userRepository.GetByIdSync(id));

            return _mapper.Map<UserResponseModel>(userEntity);
        }

        public async Task Add(UserRequestModel entity)
        {
            var userEntity = _mapper.Map<UserEntity>(entity);           
            _userRepository.Add(userEntity);
            await _userRepository.SaveChangesAsync();
        }

        public async Task Update(UserRequestModel entity, int id)
        {
            UserEntity productEntityFound = await _userRepository.GetByIdAsync(id) ?? throw new Exception("El usuario no existe");

            var productEntity = _mapper.Map(entity, productEntityFound);

            await _userRepository.UpdateAsync(productEntity);
            await _userRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _userRepository.DeleteAsync(id);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<bool> CheckUser(string email, string password)
        {
            return _userRepository.CheckUser(email, password);
        }
    }
}
