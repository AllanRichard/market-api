using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using market.API.Domain.Models;
using market.API.Domain.Services;
using market.API.Resources;
using AutoMapper;

namespace market.API.Controllers
{
  [Route("/api/categories")]
  public class CategoryController : Controller
  {
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
      _categoryService = categoryService;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryResource>>> GetAllAsync()
    {
      var categories = await _categoryService.ListAsync();
      var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
      if (resources != null)
      {
        return Ok(resources);
      }
      return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> FindByIdAsync(int id)
    {
      var findByIdAsync = await _categoryService.FindByIdAsync(id);
      var category = _mapper.Map<CategoryResource>(findByIdAsync);
      if (category != null)
      {
        return Ok(category);
      }
      return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync([FromBody] CategoryResource categoryResource)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      var category = _mapper.Map<Category>(categoryResource);
      await _categoryService.AddAsync(category);
      return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] CategoryResource categoryResource)
    {
      var category = _mapper.Map<Category>(categoryResource);
      if (category.Id != id)
      {
        return BadRequest();
      }
      await _categoryService.Update(id, category);
      return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveByIdAsync(int id)
    {
      var removeByIdAsync = await _categoryService.RemoveByIdAsync(id);
      if (removeByIdAsync != null)
      {
        return Ok(removeByIdAsync);
      }
      return BadRequest();
    }
  }
}