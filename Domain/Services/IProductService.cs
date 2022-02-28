using System.Collections.Generic;
using System.Threading.Tasks;
using market.API.Domain.Models;

namespace market.API.Domain.Services
{
  public interface IProductService
  {
    Task<IEnumerable<Product>> ListAsync();
    Task<Product> FindByIdAsync(int id);
    Task AddAsync(Product product);
    Task Update(int id, Product product);
    Task<Product> RemoveByIdAsync(int id);
  }
}