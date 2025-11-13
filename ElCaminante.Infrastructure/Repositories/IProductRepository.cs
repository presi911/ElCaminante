using ElCaminante.Domain.Entities;

namespace ElCaminante.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task<int> AddAsync(Product product);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
    }
}