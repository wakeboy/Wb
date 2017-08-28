using Microsoft.EntityFrameworkCore;
using Wb.DomainCore;

namespace Wb.PersistenceExample.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public override void Map(object modelBuilder)
        {
            var mb = (ModelBuilder)modelBuilder;
            mb.Entity<Product>().ToTable("Product");
        }

    }
}
