using mvvmApp.Dal.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace mvvmApp.Dal.Abstract.Repositories
{
    public class ItemRepositoryEF : IRepository<Item>
    {
        private ApplicationContext db;
        public ItemRepositoryEF(ApplicationContext context)
        {
            db = context;
        }
        public void Create(Item item)
        {
            db.Items.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            Save();
        }

        public IEnumerable<Item> GetAllItems()
        {
            return db.Items;
        }

        public Item GetItem(int id)
        {
            Item item = db.Items.Find(id);
            return item;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Item item)
        {
            try 
            {
                db.Entry(item).State = EntityState.Modified;
                Save();

            }
            catch(Exception ex) 
            {
                try
                {
                    var entity = db.Set<Item>()
                    .Local
                    .FirstOrDefault(f => f.Id == item.Id);
                    db.Entry(entity).State = EntityState.Detached;
                    db.Entry(item).State = EntityState.Modified;
                    Save();
                }
                catch (Exception exeption)
                {
                    var ItemUp = db.Items.Find(item.Id);
                    ItemUp = item;
                    bool saveFailed;
                    do
                    {
                        saveFailed = false;
                        try
                        {
                            Save();


                        }
                        catch (DbUpdateConcurrencyException Concurrencyex)
                        {
                            Concurrencyex.Entries.Single().Reload();
                        }
                    } while (saveFailed);

                }
            }

            

        }
    }
}
