using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Dto;

namespace Project_NetCore_MongoDB.Services.Interface
{
    public interface IUsersService
    {
        Task<List<Users>> GetAllAsync();
        Task<Users> LoginUser(string email);
        Task<Users> CreateAsync(Users user);
        Task<Users> RegisterAsync(UsersDto user);
        Task<Users> GetByIdAsync(string id);
        Task<Users> GetByEmail(string email);
        Task UpdateAsync(string id, Users user);
        Task DeleteAsync(string id);
    }
}
