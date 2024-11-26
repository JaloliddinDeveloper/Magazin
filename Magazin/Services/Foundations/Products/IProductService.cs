using Magazin.Models.Foundations.Products;

namespace Magazin.Services.Foundations.Products
{
    public interface IProductService
    {
        ValueTask<Product> RetrieveProductByIdAsync(int productId);
        ValueTask<Product> RemoveProductAsync(int productId);
    }
}
