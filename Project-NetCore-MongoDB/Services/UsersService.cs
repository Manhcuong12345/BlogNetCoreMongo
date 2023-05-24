using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Services.Interface;
using Project_NetCore_MongoDB.Repository;
using Project_NetCore_MongoDB.Repository.Interface;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Project_NetCore_MongoDB.Dto;

namespace Project_NetCore_MongoDB.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersService(IUsersRepository authRepository, IMapper mapper)
        {
            _userRepository = authRepository;
            _mapper = mapper;
        }

        public async Task<Users> CreateAsync(Users user)
        {
            return await _userRepository.CreateAsync(user);
        }

        public async Task<Users> RegisterAsync(UsersDto user)
        {
            var dataMapper = _mapper.Map<Users>(user);
            return await _userRepository.RegisterAsync(dataMapper); 
        }

        public async Task<List<Users>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<Users> GetByIdAsync(string id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<Users> GetByEmail(string email)
        {
            return await _userRepository.GetByEmail(email);
        }

        public async Task<Users> LoginUser(string email)
        {
            return await _userRepository.LoginUser(email);
        }

        public Task UpdateAsync(string id, Users user)
        {
            return _userRepository.UpdateAsync(id, user);
        }

        public Task DeleteAsync(string id)
        {
            return _userRepository.DeleteAsync(id);
        }
    }
}
