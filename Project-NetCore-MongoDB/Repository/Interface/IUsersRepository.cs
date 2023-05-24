using Project_NetCore_MongoDB.Dto;
using Project_NetCore_MongoDB.Models;

namespace Project_NetCore_MongoDB.Repository.Interface
{
    public interface IUsersRepository
    {
        Task<List<Users>> GetAllAsync();

        Task<Users> LoginUser(string email);

        Task<Users> CreateAsync(Users user);

        Task<Users> GetByIdAsync(string id);

        Task<Users> GetByEmail(string email);

        Task UpdateAsync(string id, Users user);

        Task DeleteAsync(string id);

        Task<Users> RegisterAsync(Users user);
    }
}
