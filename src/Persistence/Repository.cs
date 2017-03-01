using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wb.Domain;

namespace Wb.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly WbDbContext<TEntity> context;
        private readonly DbSet<TEntity> set;

        public Repository(WbDbContext<TEntity> context)
        {
            this.context = context;
            this.set = context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            set.Remove(entity);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            set.RemoveRange(entities);
        }

        public List<TEntity> Query(Func<TEntity, bool> query)
        {
            return set.AsNoTracking().Where(query).ToList();
        }

        public TEntity Get(int id)
        {
            return set.AsNoTracking().SingleOrDefault(e => e.Id.Equals(id));
        }

        public List<TEntity> GetAll()
        {
            return set.ToList();
        }

        public void Insert(TEntity entity)
        {
            set.Add(entity);
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            set.AddRange(entities);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            set.Update(entity);
        }
    }
}
