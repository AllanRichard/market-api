using System.Collections.Generic;
using System.Threading.Tasks;
using market.API.Domain.Models;

namespace market.API.Domain.Repositories
{
  public interface IProductRepository
  {
    Task<IEnumerable<Product>> ListAsync();
    Task AddAsync(Product product);
    Task<Product> FindByIdAsync(int id);
    Task Update(int id, Product product);
    Task<Product> RemoveByIdAsync(int id);
    Task<Product> FindProductByCategoryId(int id);
  }
}