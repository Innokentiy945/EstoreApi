using CartAPI.Context;
using Microsoft.EntityFrameworkCore;
using ProductsManagementAPI.Context;

namespace CartAPI.Repository;

public class CartRepository : ICartRepository
{
    private CartContext _cartContext;
    private ProductContext _productContext;
    private Logger<CartRepository> _logger;

    public CartRepository(CartContext cartContext, Logger<CartRepository> logger, ProductContext productContext)
    {
        _cartContext = cartContext;
        _logger = logger;
        _productContext = productContext;
    }
    
    public async Task GoToPaymentGate()
    {
        var resultCart = await _cartContext.Cart.ToListAsync();
        var resultProduct = await _productContext.Product.ToListAsync();
        
        try
        {
            _logger.LogInformation("Go to payment and deleting all products");
            if (resultCart != null || resultProduct != null)
            {
                _logger.LogInformation("CONFORMATION ORDER!!");
                _logger.LogInformation("PROCEED PAYMENT!!");
                _logger.LogInformation("PAYMENT ACCEPTED!!");
                _cartContext.Cart.RemoveRange(resultCart);
                _productContext.Product.RemoveRange(resultProduct);
                await _cartContext.SaveChangesAsync();
                await _productContext.SaveChangesAsync();
            }
        }
        catch(Exception ex)
        {
            _logger.LogInformation(ex.Message);
            throw;
        }
    }

    public async Task RemoveProduct(Guid id)
    {
        var result = await _cartContext.Cart.FirstOrDefaultAsync(x=>x.Id == id);
        
        try
        {
            _logger.LogInformation("Deleting product");
            if (result != null)
            {
                _cartContext.Cart.Remove(result);
                await _cartContext.SaveChangesAsync();
            }
        }
        catch(Exception ex)
        {
            _logger.LogInformation(ex.Message);
            throw;
        }
    }

    public async Task RemoveAllProducts()
    {
        var result = await _cartContext.Cart.ToListAsync();
        
        try
        {
            _logger.LogInformation("Deleting all products");
            if (result != null)
            {
                _cartContext.Cart.RemoveRange(result);
                await _cartContext.SaveChangesAsync();
            }
        }
        catch(Exception ex)
        {
            _logger.LogInformation(ex.Message);
            throw;
        }
    }
}