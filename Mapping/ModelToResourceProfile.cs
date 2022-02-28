using AutoMapper;
using market.API.Domain.Models;
using market.API.Resources;

namespace Supermarket.API.Mapping
{
  public class ModelToResourceProfile : Profile
  {
    public ModelToResourceProfile()
    {
      CreateMap<Category, CategoryResource>().ReverseMap();
      CreateMap<Product, ProductResource>().ReverseMap();
      CreateMap<Product, ProductResourceSave>().ReverseMap();
    }
  }
}