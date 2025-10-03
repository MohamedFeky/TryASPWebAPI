using TryASPWepAPI.Models;

namespace TryASPWepAPI.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllAsync();

        public Task<Product> GetByIdAsync(int id);

        public Task CreateProductAsync(Product product);

        public Task UpdateProductAsync(Product product);

        public Task DeleteProductAsync(int id);
        public Task SaveAsync();

    }
}
