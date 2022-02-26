using System.Collections.Generic;

namespace market.API.Domain.Models
{
  public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IList<Product> Products { get; set; } = new List<Product>();
  }
}