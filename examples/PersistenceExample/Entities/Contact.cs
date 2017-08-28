using Microsoft.EntityFrameworkCore;
using Wb.DomainCore;

namespace Wb.PersistenceExample.Entities
{
    public class Contact : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public override void Map(object modelBuilder)
        {
            var mb = (ModelBuilder)modelBuilder;
            mb.Entity<Contact>().ToTable("Contact");
        }
    }
}
