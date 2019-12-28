using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract.Interfaces;

namespace mvvmApp.Dal.Abstract.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public ApplicationContext Context { get; set; }

        public DbSet<TEntity> DbSet
        {
            get { return Context.Set<TEntity>(); }
        }

        public GenericRepository(ApplicationContext context)
        {
            Context = context;
        }
        public void Create(TEntity entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            Context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
