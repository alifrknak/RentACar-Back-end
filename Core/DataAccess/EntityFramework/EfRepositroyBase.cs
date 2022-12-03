using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfRepositroyBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()

    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deleted = context.Entry(entity);
                deleted.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Func<TEntity, bool> filter = null)
        {
            using (TContext context = new TContext())
            {
                if (filter != null)
                {
                    return context.Set<TEntity>().Single(filter);
                }
                throw new Exception("id gir");
            }
        }

        public List<TEntity> GetAll(Func<TEntity, bool> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                     ? context.Set<TEntity>().ToList()
                     : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updated = context.Entry(entity);
                updated.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
