using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using market.API.Domain.Models;
using market.API.Domain.Services;
using market.API.Resources;

namespace market.API.Controllers
{
  [Route("/api/products")]
  public class ProductController : Controller
  {
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)
    {
      _productService = productService;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResource>>> GetAllAsync()
    {
      var products = await _productService.ListAsync();
      var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
      if (resources != null)
      {
        return Ok(resources);
      }
      return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> FindByIdAsync(int id)
    {
      var findByIdAsync = await _productService.FindByIdAsync(id);
      var product = _mapper.Map<ProductResource>(findByIdAsync);
      if (product != null)
      {
        return Ok(product);
      }
      return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync([FromBody] ProductResourceSave productResourceSave)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      var product = _mapper.Map<Product>(productResourceSave);
      await _productService.AddAsync(product);
      return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] ProductResourceSave productResourceSave)
    {
      var product = _mapper.Map<Product>(productResourceSave);
      if (product.Id != id)
      {
        return BadRequest();
      }
      await _productService.Update(id, product);
      return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveByIdAsync(int id)
    {
      var removeByIdAsync = await _productService.RemoveByIdAsync(id);
      if (removeByIdAsync != null)
      {
        return Ok(removeByIdAsync);
      }
      return NotFound();
    }
  }
}