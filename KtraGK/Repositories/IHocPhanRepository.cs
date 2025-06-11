using System.Collections.Generic;
using System.Threading.Tasks;
using KtraGK.Models;

namespace KtraGK.Repositories
{
    public interface IHocPhanRepository
    {
        Task<IEnumerable<HocPhan>> GetAllAsync();
    }
}
