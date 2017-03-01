using Microsoft.EntityFrameworkCore;
using Wb.Persistence;
using Wb.PersistenceExample.Entities;

namespace Wb.PersistenceExample.Repository
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(WbDbContext<Contact> context) : base(context)
        {
        }
    }
}
