using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using market.API.Domain.Repositories;
using market.API.Domain.Services;
using market.API.Persistence.Contexts;
using market.API.Persistence.Repositories;
using market.API.Services;
using AutoMapper;
using Microsoft.OpenApi.Models;

namespace market.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

      services.AddDbContext<AppDbContext>(options =>
      {
        options.UseInMemoryDatabase("market-api-in-memory");
      });

      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<ICategoryService, CategoryService>();
      services.AddScoped<IProductRepository, ProductRepository>();
      services.AddScoped<IProductService, ProductService>();

      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
              Title = "Market API",
              Version = "v1",
              Description = "Exemplo de API REST criada com o ASP.NET Core 3.1",
              Contact = new OpenApiContact
              {
                Name = "Allan Richard",
                Url = new Uri("https://github.com/AllanRichard")
              }
            });
            c.UseInlineDefinitionsForEnums();
        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.EnvironmentName.Equals("Development"))
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("./v1/swagger.json", "Market API V1");
      });

      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
