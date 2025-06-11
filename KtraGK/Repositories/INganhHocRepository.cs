using System.Collections.Generic;
using System.Threading.Tasks;
using KtraGK.Models;
namespace KtraGK.Repositories;

public interface INganhHocRepository
{
    Task<IEnumerable<NganhHoc>> GetAllAsync();
    Task<NganhHoc> GetByIdAsync(string maNganh);
}
