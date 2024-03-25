namespace CartAPI.Repository;

public interface ICartRepository
{
    public Task GoToPaymentGate();

    public Task RemoveProduct(Guid id);

    public Task RemoveAllProducts();
}