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
      _context.Categories.Add(category);
      await _context.SaveChangesAsync();
    }

    public async Task<Category> FindByIdAsync(int id)
    {
      return await _context.Categories.FindAsync(id);
    }

    public async Task Update(int id, Category category)
    {
      _context.Entry(category).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task<Category> RemoveByIdAsync(int id)
    {
      var categoryToDelete = await _context.Categories.FirstOrDefaultAsync(e => e.Id == id);

      if (categoryToDelete != null)
      {
        _context.Categories.Remove(categoryToDelete);
        await _context.SaveChangesAsync();
        return categoryToDelete;
      }
      return null;
    }
  }
}