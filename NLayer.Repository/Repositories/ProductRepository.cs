using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            
            return await _context.Products.Include(x => x.Category).ToListAsync();

        }
    }
}
