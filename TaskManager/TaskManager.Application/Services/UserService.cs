using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManager.Application.Models.Users;
using TaskManager.Application.Services.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;
using TaskManager.Application.Services;
using static TaskManager.Client.Data.Dtos.ServiceResponses;
using System.Security.Cryptography;


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

        public async Task<LoginResponse> CheckUser(string email, string password)
        {
            var userEntity = await Task.Run(() => _userRepository.CheckUser(email, password));

            if (userEntity != null)
            {
                var user = _mapper.Map<UserResponseModel>(userEntity);
                int keySizeInBytes = 16;

                // Generar una clave aleatoria
                byte[] key = GenerateRandomKey(keySizeInBytes);
                string hexKey = ByteArrayToHexString(key);
                var jwtService = new JWTGenerator("ab1b3089779b50d1b9bb03c3e15be7a0", "tarea", "tarea");
                string token = jwtService.GenerateToken(user.Name, user.Email);
                return new LoginResponse(true, token!, user.Id.ToString());
                
            }
            else
            {
                UserResponseModel userEmpty = new UserResponseModel();
                return new LoginResponse(false, null!, string.Empty);                
            }           
        }

        static byte[] GenerateRandomKey(int sizeInBytes)
        {
            byte[] key = new byte[sizeInBytes];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return key;
        }

        static string ByteArrayToHexString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

    }
}
