using System.Collections.Generic;
using System.Threading.Tasks;
using market.API.Domain.Models;
using market.API.Domain.Services;
using market.API.Domain.Repositories;

namespace market.API.Services
{
  public class ProductService : IProductService
  {
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
      return await _productRepository.ListAsync();
    }

    public async Task<Product> FindByIdAsync(int id)
    {
      return await _productRepository.FindByIdAsync(id);
    }

    public async Task AddAsync(Product product)
    {
      await _productRepository.AddAsync(product);
    }
    public async Task Update(int id, Product product)
    {
      await _productRepository.Update(id, product);
    }

    public async Task<Product> RemoveByIdAsync(int id)
    {
      return await _productRepository.RemoveByIdAsync(id);
    }
  }
}