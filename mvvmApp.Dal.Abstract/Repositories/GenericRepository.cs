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
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public ApplicationContext Context { get; set; }

        public GenericRepository(ApplicationContext context)
        {
            Context = context;
        }
        public void Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().AsNoTracking().FirstOrDefault(e=>e.Id==id);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();            
        }
    }
}
