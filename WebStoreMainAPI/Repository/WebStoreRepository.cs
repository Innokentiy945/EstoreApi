using CartAPI.Context;
using CartAPI.Model;
using Microsoft.EntityFrameworkCore;
using ProductsManagementAPI.Context;
using ProductsManagementAPI.Model;

namespace WebStoreMainAPI.Repository;

public class WebStoreRepository : IWebStoreRepository
{
    private ProductContext _productContext;
    private CartContext _cartContext;
    private ILogger _logger;

    public WebStoreRepository(ProductContext productContext, CartContext cartContext, ILogger<WebStoreRepository> logger)
    {
        _productContext = productContext;
        _cartContext = cartContext;
        _logger = logger;
    }
    
    public async Task<List<CartModel>> AddProductToCart()
    {
        _logger.LogInformation("Adding product to cart!");
        var result = await (from p in _productContext.Product
            join c in _cartContext.Cart on p.Id equals c.Id
            select new CartModel
            {
                Id = p.Id,
                Description = p.Description,
                Price = p.Price
            }).ToListAsync();
        
        _logger.LogInformation("Added product to cart!");
        return result;
    }
    
    public async Task<IEnumerable<ProductModel>> GetAllProducts()
    {
        try
        {
            _logger.LogInformation("Get all products");
            return await _productContext.Product.ToListAsync();
        }
        catch(Exception ex)
        {
            _logger.LogInformation(ex.Message);
            throw;
        }
    }

    public async Task<ProductModel> GetProductById(Guid id)
    {
        try
        {
            _logger.LogInformation("Get product by Id");
            var result = await _productContext.Product.FirstOrDefaultAsync(x=>x.Id == id);
            return result;
        }
        catch(Exception ex)
        {
            _logger.LogInformation(ex.Message);
            throw;
        }
    }
    
    public async Task<List<ProductModel>> SearchByTags(string tags)
    {
        try
        {
            _logger.LogInformation("Getting the products by tags after search");
            IQueryable<ProductModel> query =  _productContext.Product;
            var list = await query.ToListAsync();
            var searchResult = list.FindAll(s => s.Tags.Contains(tags));
            return searchResult;
        }
        catch(Exception ex)
        {
            _logger.LogInformation(ex.Message);
            throw;
        }
    }
}