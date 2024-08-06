using Microsoft.EntityFrameworkCore;
using PromoMashTest.Server.Core.Entities;
using PromoMashTest.Server.Core.Interfaces;
using PromoMashTest.Server.Infrastructure.Data;

namespace PromoMashTest.Server.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
