using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using market.API.Domain.Models;
using market.API.Domain.Services;

namespace market.API.Controllers
{
  [Route("/api/products")]
  public class ProductController : Controller
  {
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
      _productService = productService;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
      var products = await _productService.ListAsync();
      return products;
    }

    [HttpGet("{id}")]
    public async Task<Product> FindByIdAsync(int id)
    {
      return await _productService.FindByIdAsync(id);
    }

    [HttpPost]
    public async Task AddAsync([FromBody] Product product)
    {
      await _productService.AddAsync(product);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] Product product)
    {
      if (product.Id != id)
      {
        return BadRequest();
      }
      await _productService.Update(id, product);
      return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<Product> RemoveByIdAsync(int id)
    {
      return await _productService.RemoveByIdAsync(id);
    }

    public async Task<Product> FindProductByCategoryId(int id)
    {
      return await _productService.FindProductByCategoryId(id);
    }
  }
}