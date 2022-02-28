using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using market.API.Domain.Models;
using market.API.Domain.Services;

namespace market.API.Controllers
{
  [Route("/api/categories")]
  public class CategoryController : Controller
  {
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;

    public CategoryController(ICategoryService categoryService, IProductService productService)
    {
      _categoryService = categoryService;
      _productService = productService;
    }

    [HttpGet]
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
      var categories = await _categoryService.ListAsync();
      return categories;
    }

    [HttpGet("{id}")]
    public async Task<Category> FindByIdAsync(int id)
    {
      return await _categoryService.FindByIdAsync(id);
    }

    [HttpPost]
    public async Task AddAsync([FromBody] Category category)
    {
      await _categoryService.AddAsync(category);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] Category category)
    {
      if (category.Id != id)
      {
        return BadRequest();
      }
      await _categoryService.Update(id, category);
      return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<Category> RemoveByIdAsync(int id)
    {
      return await _categoryService.RemoveByIdAsync(id);
    }
  }
}