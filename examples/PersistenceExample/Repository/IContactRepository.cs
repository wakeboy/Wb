using System;
using System.Collections.Generic;
using System.Text;
using Wb.Persistence;
using Wb.PersistenceExample.Entities;

namespace Wb.PersistenceExample.Repository
{
    public interface IContactRepository : IRepository<Contact>
    {
    }
}
