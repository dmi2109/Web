using Microsoft.EntityFrameworkCore;
using KtraGK.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KtraGK.Repositories
{
    public class HocPhanRepository : IHocPhanRepository
    {
        private readonly ApplicationDbContext _context;

        public HocPhanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HocPhan>> GetAllAsync()
        {
            return await _context.HocPhans.ToListAsync();
        }
    }
}
