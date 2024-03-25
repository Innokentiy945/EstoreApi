using CartAPI.Model;
using Microsoft.EntityFrameworkCore;
using ProductsManagementAPI.Model;

namespace WebStoreMainAPI.Context;

public class MasterContext : DbContext
{
    public MasterContext(DbContextOptions<MasterContext> options) : base(options){ }

    public DbSet<ProductModel> Product { get; set; }

    public DbSet<CartModel> Cart { get; set; }
}