using mvvmApp.Dal.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace mvvmApp.Dal.Abstract.Repositories
{
    public class OrderRepositoryEF : IRepository<Order>
    {
        ApplicationContext db;
        public OrderRepositoryEF(ApplicationContext context)
        {
            db = context;
        }
        public void Create(Order item)
        {
            db.Orders.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            Order item = db.Orders.Find(id);
            db.Orders.Remove(item);
            Save();
        }

        public IEnumerable<Order> GetAllItems()
        {
            return db.Orders;
        }

        public Order GetItem(int id)
        {
            Order order = db.Orders.FirstOrDefault(o=>o.Id == id);
            return order;
        }
        public IQueryable GetOrderAndItems(int id)
        {
            IQueryable order = db.Orders.Include(o => o.ItemOrders);
            return order;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Order item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            Save();
        }
    }
}
