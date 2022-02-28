namespace market.API.Resources
{
  public class ProductResource
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Brand { get; set; }
    public CategoryResource Category { get; set; }
  }
}