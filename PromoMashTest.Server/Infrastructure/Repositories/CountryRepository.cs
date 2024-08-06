using PromoMashTest.Server.Core.Entities;
using PromoMashTest.Server.Core.Interfaces;
using PromoMashTest.Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace PromoMashTest.Server.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _context.Countries.Include(c => c.Provinces).ToListAsync();
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await _context.Countries.Include(c => c.Provinces).SingleOrDefaultAsync(c => c.Id == id);
        }
    }

}
