using CartAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CartAPI.Context;

public class CartContext : DbContext
{
    public CartContext(DbContextOptions<CartContext> options) : base(options) { }
    public DbSet<CartModel> Cart { get; set; }
}