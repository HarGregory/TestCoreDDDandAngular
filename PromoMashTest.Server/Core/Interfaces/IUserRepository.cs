using PromoMashTest.Server.Core.Entities;

namespace PromoMashTest.Server.Core.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByEmailAsync(string email);
    }

    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync();
        Task<Country> GetByIdAsync(int id);
    }
}
