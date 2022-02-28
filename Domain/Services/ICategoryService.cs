using System.Collections.Generic;
using System.Threading.Tasks;
using market.API.Domain.Models;

namespace market.API.Domain.Services
{
  public interface ICategoryService
  {
    Task<IEnumerable<Category>> ListAsync();
    Task<Category> FindByIdAsync(int id);
    Task AddAsync(Category category);
    Task Update(int id, Category category);
    Task<Category> RemoveByIdAsync(int id);
  }
}