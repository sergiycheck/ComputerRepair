using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Dal.Abstract.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        void Create(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
