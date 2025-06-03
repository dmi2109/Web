using System.Collections.Generic;
using System.Threading.Tasks;
using Buoi_6.Models;

namespace Buoi_6.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);

        Task AddAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync(int id);
    }
}
