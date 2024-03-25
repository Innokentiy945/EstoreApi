using Microsoft.EntityFrameworkCore;
using ProductsManagementAPI.Model;

namespace ProductsManagementAPI.Context;

public class ProductContext : DbContext 
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
    public DbSet<ProductModel> Product { get; set; }
}