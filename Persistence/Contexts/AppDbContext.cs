using Microsoft.EntityFrameworkCore;
using market.API.Domain.Models;

namespace market.API.Persistence.Contexts
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Category>().ToTable("Categories");
      builder.Entity<Category>().HasKey(p => p.Id);
      builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(150);
      builder.Entity<Category>().Property(p => p.Description).IsRequired().HasMaxLength(200);
      builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId).IsRequired();

      builder.Entity<Category>().HasData(
        new Category { Id = 1, Name = "Frutas", Description = "Categoria de Frutas" },
        new Category { Id = 2, Name = "Bebidas", Description = "Categoria de Bebidas" }
      );

      builder.Entity<Product>().ToTable("Products");
      builder.Entity<Product>().HasKey(p => p.Id);
      builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
      builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(250);
      builder.Entity<Product>().Property(p => p.Price).IsRequired();
      builder.Entity<Product>().HasOne(p => p.Category).WithMany(e => e.Products).OnDelete(DeleteBehavior.SetNull);

      builder.Entity<Product>().HasData(
        new Product { Id = 1, Name = "Maçã", Price = 1, CategoryId = 1 },
        new Product { Id = 2, Name = "Pêra", Price = 1, CategoryId = 1 },
        new Product { Id = 3, Name = "Coca Cola", Price = 8, CategoryId = 2 },
        new Product { Id = 4, Name = "Sprite", Price = 8, CategoryId = 2 }
      );
    }
  }
}