using CartAPI.Model;
using Microsoft.AspNetCore.Mvc;
using ProductsManagementAPI.Model;
using WebStoreMainAPI.Repository;

namespace WebStoreMainAPI.Controllers;

[ApiController]
[Route("api/masterApi")]
public class WebStoreMasterApiController : ControllerBase
{
    private readonly IWebStoreRepository _webStoreRepository;
    
    public WebStoreMasterApiController(IWebStoreRepository webStoreRepository)
    {
        _webStoreRepository = webStoreRepository;
    }

    [HttpPost]
    [Route("master/addToCart")]
    public async Task<List<CartModel>> AddProductToCart()
    {
        return await _webStoreRepository.AddProductToCart();
    }

    [HttpGet]
    [Route("master/getAll")]
    public async Task<IEnumerable<ProductModel>> GetAllProducts()
    {
       return await _webStoreRepository.GetAllProducts();
    }

    [HttpGet]
    [Route("master/getProduct/{id}")]
    public async Task<ProductModel> GetProductById(Guid id)
    {
        return await _webStoreRepository.GetProductById(id);
    }

    [HttpGet]
    [Route("searchProduct/{tags}")]
    public async Task<List<ProductModel>> SearchByTags(string tags)
    {
        return await _webStoreRepository.SearchByTags(tags);
    }
}