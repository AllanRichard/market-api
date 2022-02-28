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

    public async Task<Category> FindByIdAsync(int id)
    {
      return await _categoryRepository.FindByIdAsync(id);
    }

    public async Task AddAsync(Category category)
    {
      await _categoryRepository.AddAsync(category);
    }
    public async Task Update(int id, Category category)
    {
      await _categoryRepository.Update(id, category);
    }

    public async Task<Category> RemoveByIdAsync(int id)
    {
      return await _categoryRepository.RemoveByIdAsync(id);
    }
  }
}