
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsManagementAPI.Model;
using ProductsManagementAPI.Repository;

namespace ProductsManagementAPI.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    [HttpGet]
    [Route("getAll")]
    public async Task<IEnumerable<ProductModel>> AllProducts()
    {
        return await _productRepository.GetAllProducts();
    }

    [HttpGet]
    [Route("getProduct/{id}")]
    public async Task<ProductModel> GetProduct(Guid id)
    {
        return await _productRepository.GetProductById(id);
    }

    [HttpGet]
    [Route("searchProduct/{tags}")]
    public async Task<List<ProductModel>> SearchProduct(string tags)
    {
        return await _productRepository.SearchByTags(tags);
    }

    [HttpPost]
    [Route("addProduct")]
    public async Task<ProductModel> AddProduct(ProductModel model)
    {
        return await _productRepository.CreateProduct(model);
    }
    
    [HttpPut]
    [Route("updateProduct")]
    public async Task<ProductModel> UpdateProduct(ProductModel model)
    {
        return await _productRepository.UpdateProduct(model);
    }

    [HttpDelete]
    [Route("deleteProduct/{id}")]
    public async Task DeleteProduct(Guid id)
    {
        await _productRepository.DeleteProduct(id);
    }
}