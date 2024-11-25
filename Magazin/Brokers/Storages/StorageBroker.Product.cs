using Magazin.Models.Foundations.Products;
using Microsoft.EntityFrameworkCore;

namespace Magazin.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Product> Products { get; set; }

        public async ValueTask<Product> InsertProductAsync(Product product) =>
            await InsertAsync(product);

        public async ValueTask<IQueryable<Product>> SelectAllProductsAsync() =>
            await SelectAllAsync<Product>();

        public async ValueTask<Product> SelectProductByIdAsync(int productId) =>
            await SelectAsync<Product>(productId);

        public async ValueTask<Product> UpdateProductAsync(Product product) =>
            await UpdateAsync(product);

        public async ValueTask<Product> DeleteProductAsync(Product product) =>
            await DeleteAsync(product);
    }
}
