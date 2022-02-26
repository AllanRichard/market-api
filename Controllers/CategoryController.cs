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

    public CategoryController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
      var categories = await _categoryService.ListAsync();
      return categories;
    }


  }
}