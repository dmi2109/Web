using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KtraGK.Models;

namespace KtraGK.Repositories
{
    public class NganhHocRepository : INganhHocRepository
    {
        private readonly ApplicationDbContext _context;

        public NganhHocRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NganhHoc>> GetAllAsync()
        {
            return await _context.NganhHocs.ToListAsync();
        }

        public async Task<NganhHoc> GetByIdAsync(string maNganh)
        {
            return await _context.NganhHocs.FindAsync(maNganh);
        }
    }
}
