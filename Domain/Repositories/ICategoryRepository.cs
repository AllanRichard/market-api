using System.Collections.Generic;
using System.Threading.Tasks;
using market.API.Domain.Models;

namespace market.API.Domain.Repositories
{
  public interface ICategoryRepository
  {
    Task<IEnumerable<Category>> ListAsync();
    Task AddAsync(Category category);
    Task<Category> FindByIdAsync(int id);
    Task Update(int id, Category category);
    Task<Category> RemoveByIdAsync(int id);
  }
}