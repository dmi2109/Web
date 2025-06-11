using System.Collections.Generic;
using System.Threading.Tasks;
using KtraGK.Models;
namespace KtraGK.Repositories;


public interface ISinhVienRepository
{
    Task<IEnumerable<SinhVien>> GetAllAsync();
    Task<SinhVien> GetByIdAsync(string id);
    Task<IEnumerable<SinhVien>> GetByNganhAsync(string maNganh);
    Task AddAsync(SinhVien sv);
    Task UpdateAsync(SinhVien sv);
    Task DeleteAsync(string id);

}
