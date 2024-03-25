using CartAPI.Context;
using CartAPI.Repository;
using Microsoft.EntityFrameworkCore;
using ProductsManagementAPI.Context;
using ProductsManagementAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DB connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProductContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddDbContext<CartContext>(x=> x.UseSqlServer(connectionString));
builder.Services.AddScoped<ICartRepository, CartRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();