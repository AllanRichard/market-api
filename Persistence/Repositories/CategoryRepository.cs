using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using market.API.Domain.Models;
using market.API.Domain.Repositories;
using market.API.Persistence.Contexts;

namespace market.API.Persistence.Repositories
{
  public class CategoryRepository : BaseRepository, ICategoryRepository
  {
    public CategoryRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Category>> ListAsync()
    {
      return await _context.Categories.ToListAsync();
    }

    public async Task AddAsync(Category category)
    {
      await _context.Categories.AddAsync(category);
    }

    public async Task<Category> FindByIdAsync(int id)
    {
      return await _context.Categories.FindAsync(id);
    }

    public void Remove(Category category)
    {
      _context.Categories.Remove(category);
    }

    public void Update(Category category)
    {
      _context.Categories.Update(category);
    }
  }
}