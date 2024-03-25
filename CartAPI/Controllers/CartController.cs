using CartAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CartAPI.Controllers;

[ApiController]
[Route("api/cart")]
public class CartController : ControllerBase
{
    private readonly ICartRepository _cartRepository;
    
    public CartController(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    [HttpGet]
    public async Task GoToPayment()
    {
        await _cartRepository.GoToPaymentGate();
    }

    [HttpDelete]
    [Route("deleteAll")]
    public async Task RemoveAllFromCart()
    {
        await _cartRepository.RemoveAllProducts();
    }

    [HttpDelete]
    [Route("deleteProduct/{id}")]
    public async Task RemoveProductById(Guid id)
    {
        await _cartRepository.RemoveProduct(id);
    }
}