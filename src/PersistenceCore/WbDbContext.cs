using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using Wb.DomainCore;

namespace Wb.PersistenceCore
{

    public class WbDbContext<TEntity> : DbContext where TEntity : Entity
    {
        public WbDbContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var instance = Activator.CreateInstance(typeof(TEntity));
            var method = instance.GetType().GetMethod("Map");
            method.Invoke(instance, new[] { modelBuilder });
        
        }
    }
}
