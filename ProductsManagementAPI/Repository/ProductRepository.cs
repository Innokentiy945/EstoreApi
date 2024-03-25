using Microsoft.EntityFrameworkCore;
using ProductsManagementAPI.Context;
using ProductsManagementAPI.Model;

namespace ProductsManagementAPI.Repository;

public class ProductRepository : IProductRepository
{
    private ProductContext _productContext;
    private ILogger _logger;

    public ProductRepository(ProductContext productContext, ILogger<ProductRepository> logger)
    {
        _productContext = productContext;
        _logger = logger;
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

    public async Task<ProductModel> CreateProduct(ProductModel model)
    {
        var result = await _productContext.AddAsync(model);
        
        try
        {
            _logger.LogInformation("Add product");
            await _productContext.SaveChangesAsync();
            return result.Entity;
        }
        catch(Exception ex)
        {
            _logger.LogInformation(ex.Message);
            throw;
        }
    }

    public async Task<ProductModel> UpdateProduct(ProductModel model)
    {
        var result = await _productContext.Product.FirstOrDefaultAsync(x=>x.Id==model.Id);
        
        try
        {
            _logger.LogInformation("Update product");
            if (result != null)
            {
                result.Id = model.Id;
                result.Description = model.Description;
                result.Price = model.Price;
                result.Tags = model.Tags;
                
                await _productContext.SaveChangesAsync();
                return result;
            }
        }
        catch(Exception ex)
        {
            _logger.LogInformation(ex.Message);
            throw;
        }

        return null;
    }

    public async Task DeleteProduct(Guid id)
    {
        var result = await _productContext.Product.FirstOrDefaultAsync(x=>x.Id==id);
        
        try
        {
            _logger.LogInformation("Delete product");
            if (result != null)
            {
                _productContext.Product.Remove(result);
                await _productContext.SaveChangesAsync();
            }
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