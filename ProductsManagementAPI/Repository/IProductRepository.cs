using ProductsManagementAPI.Model;

namespace ProductsManagementAPI.Repository;

public interface IProductRepository
{
    public Task<IEnumerable<ProductModel>> GetAllProducts();

    public Task<ProductModel> GetProductById(Guid id);

    public Task<ProductModel> CreateProduct(ProductModel model);

    public Task<ProductModel> UpdateProduct(ProductModel model);

    public Task DeleteProduct(Guid id);

    public Task<List<ProductModel>> SearchByTags(string tags);
}