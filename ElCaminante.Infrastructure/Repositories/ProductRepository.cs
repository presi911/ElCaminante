using ElCaminante.Domain.Entities;
using ElCaminante.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ElCaminante.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ElCaminanteDbContext _context;

        public ProductRepository(ElCaminanteDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var existing = await _context.Products.FindAsync(product.Id);
            if (existing == null)
                return false;

            _context.Entry(existing).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}