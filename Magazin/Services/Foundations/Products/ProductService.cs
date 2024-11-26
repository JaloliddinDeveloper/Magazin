using Magazin.Brokers.Storages;
using Magazin.Models.Foundations.Products;

namespace Magazin.Services.Foundations.Products
{
    public class ProductService: IProductService
    {
        private readonly IStorageBroker storageBroker;

        public ProductService(IStorageBroker storageBroker)=>
            this.storageBroker = storageBroker;

        public async ValueTask<Product> RetrieveProductByIdAsync(int productId)=>
            await this.storageBroker.SelectProductByIdAsync(productId);
        
        public async ValueTask<Product> RemoveProductAsync(int productId)
        {
            Product maybeProduct = await this.storageBroker.SelectProductByIdAsync(productId);

            return await this.storageBroker.DeleteProductAsync(maybeProduct);
        }
    }
}
