using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using market.API.Domain.Models;
using market.API.Domain.Repositories;
using market.API.Persistence.Contexts;

namespace market.API.Persistence.Repositories
{
  public class ProductRepository : BaseRepository, IProductRepository
  {
    public ProductRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Product>> ListAsync()
    {
      return await _context.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
      _context.Products.Add(product);
      await _context.SaveChangesAsync();
    }

    public async Task<Product> FindByIdAsync(int id)
    {
      return await _context.Products.FindAsync(id);
    }

    public async Task Update(int id, Product product)
    {
      _context.Entry(product).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task<Product> RemoveByIdAsync(int id)
    {
      var productToDelete = await _context.Products.FirstOrDefaultAsync(e => e.Id == id);

      if (productToDelete != null)
      {
        _context.Products.Remove(productToDelete);
        await _context.SaveChangesAsync();
        return productToDelete;
      }
      return null;
    }

    public async Task<Product> FindProductByCategoryId(int id)
    {
      var productByCategoryId = await _context.Products.FirstOrDefaultAsync(e => e.CategoryId == id);
      return productByCategoryId;
    }
  }
}