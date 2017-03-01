using Microsoft.EntityFrameworkCore;
using Wb.Persistence;
using Wb.PersistenceExample.Entities;

namespace Wb.PersistenceExample.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(WbDbContext<Product> context) : base(context)
        {
            
        }
    }
}
