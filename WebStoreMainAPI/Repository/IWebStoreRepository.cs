using CartAPI.Model;
using ProductsManagementAPI.Model;

namespace WebStoreMainAPI.Repository;

public interface IWebStoreRepository
{
    public Task<List<CartModel>> AddProductToCart();
    
    public Task<List<ProductModel>> SearchByTags(string tags);
    
    public Task<IEnumerable<ProductModel>> GetAllProducts();

    public Task<ProductModel> GetProductById(Guid id);
}