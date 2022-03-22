using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebShop.Data;
using WebShop.Models.Enteties;

namespace WebShop.Repositories
{
    public class ProductRepository
    {
        private ApplicationDbContext db;

        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await db.Products.Include(c => c.Category).Include(c => c.Size).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await db.Products.Include(c => c.Category).Include(c => c.Size).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> FilterByCategoryAsync(PlantCategory category)
        {
            var products = await GetAllProductsAsync();
            products = products.Where(p => p.Category == category);

            return products.ToList();
        }

        public async Task<IEnumerable<Product>> FilterBySize(PlantSize size)
        {
            var products = await GetAllProductsAsync();
            products = products.Where(p => p.Size == size);

            return products.ToList();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

    }
}
