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
            
            try
            {
                DbSet.Remove(entity);
                Context.SaveChanges();

            }
            catch (Exception ex)
            {

            }
            try
            {

                Context.Entry(entity).State = EntityState.Deleted;
                Context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
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
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
            }
            catch (Exception ex)
            {

                try
                {
                    Context.Entry(entity).State = EntityState.Detached;
                    Context.Entry(entity).State = EntityState.Added;
                    Context.SaveChanges();


                }
                catch (Exception exeption)
                {

                    
                }
            }
            
        }
    }
}
