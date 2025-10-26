using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.product.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.product.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _context.product.AddAsync(product);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.product.Update(product);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.product.FindAsync(id);

            if (product != null)
            {
                _context.product.Remove(product);

                await _context.SaveChangesAsync();
            }
        }
    }
}
