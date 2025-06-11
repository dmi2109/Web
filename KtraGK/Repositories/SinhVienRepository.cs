using Microsoft.EntityFrameworkCore;
using KtraGK.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace KtraGK.Repositories;

public class SinhVienRepository : ISinhVienRepository
{
    private readonly ApplicationDbContext _context;

    public SinhVienRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SinhVien>> GetAllAsync()
    {
        return await _context.SinhViens.Include(s => s.NganhHoc).ToListAsync();
    }

    public async Task<SinhVien> GetByIdAsync(string id)
    {
        return await _context.SinhViens.Include(s => s.NganhHoc)
                                       .FirstOrDefaultAsync(s => s.MaSV == id);
    }

    public async Task<IEnumerable<SinhVien>> GetByNganhAsync(string maNganh)
    {
        return await _context.SinhViens.Include(s => s.NganhHoc)
                                       .Where(s => s.MaNganh == maNganh)
                                       .ToListAsync();
    }
    public async Task AddAsync(SinhVien sv)
    {
        _context.SinhViens.Add(sv);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(SinhVien sv)
    {
        _context.SinhViens.Update(sv);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var sv = await _context.SinhViens.FindAsync(id);
        if (sv != null)
        {
            _context.SinhViens.Remove(sv);
            await _context.SaveChangesAsync();
        }
    }

}
