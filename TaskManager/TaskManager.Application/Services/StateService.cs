using AutoMapper;
using TaskManager.Application.Models.Users;
using TaskManager.Application.Services.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Repositories;

namespace TaskManager.Application.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;

        public StateService(IStateRepository stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StateResponseModel>> GetAll()
        {
            var stateEntity = await _stateRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<StateResponseModel>>(stateEntity); ;
        }

        public async Task<StateResponseModel> GetById(int id)
        {
            var stateEntity = await _stateRepository.GetByIdAsync(id);

            return _mapper.Map<StateResponseModel>(stateEntity);
        }
        public async Task Add(StateRequestModel entity)
        {
            var stateEntity = _mapper.Map<StateEntity>(entity);          
            _stateRepository.Add(stateEntity);
            await _stateRepository.SaveChangesAsync();
        }

        public async Task Update(StateRequestModel entity, int id)
        {
            StateEntity stateEntityNotFound = await _stateRepository.GetByIdAsync(id) ?? throw new Exception("El usuario no existe");

            var stateEntity = _mapper.Map(entity, stateEntityNotFound);

            await _stateRepository.UpdateAsync(stateEntity);
            await _stateRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _stateRepository.DeleteAsync(id);
            await _stateRepository.SaveChangesAsync();
        }
    }
}
