using Magazin.Models.Foundations.Products;

namespace Magazin.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Product> InsertProductAsync(Product product);
        ValueTask<IQueryable<Product>> SelectAllProductsAsync();
        ValueTask<Product> SelectProductByIdAsync(int productId);
        ValueTask<Product> UpdateProductAsync(Product product);
        ValueTask<Product> DeleteProductAsync(Product product);
    }
}
