using System.Collections.Generic;
using System.Threading.Tasks;
using market.API.Domain.Models;

namespace market.API.Domain.Services
{
  public interface ICategoryService
  {
    Task<IEnumerable<Category>> ListAsync();
  }
}