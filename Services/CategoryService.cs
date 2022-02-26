using System.Collections.Generic;
using System.Threading.Tasks;
using market.API.Domain.Models;
using market.API.Domain.Services;
using market.API.Domain.Repositories;

namespace market.API.Services
{
  public class CategoryService : ICategoryService
  {
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> ListAsync()
    {
      return await _categoryRepository.ListAsync();
    }
  }
}