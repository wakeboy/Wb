using System;
using System.Collections.Generic;
using System.Text;
using Wb.PersistenceCore;
using Wb.PersistenceExample.Entities;

namespace Wb.PersistenceExample.Repository
{
    public interface IContactRepository : IRepository<Contact>
    {
    }
}
