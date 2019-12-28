using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using mvvmApp.Dal.Abstract;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract.Repositories;

namespace WCFServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ItemService" in both code and config file together.
    public class ItemService : IItemService
    {
        ItemRepositoryEF repoEf;
        public ItemService() 
        {
            repoEf = new ItemRepositoryEF(new ApplicationContext("mvvmApp.Dal.Abstract.Entities.ApplicationContext"));
        }
        public void Create(Item item)
        {
            repoEf.Create(item);
        }

        public void Delete(int id)
        {
            repoEf.Delete(id);
        }

        public Item[] GetAllItems()
        {
            Item[] items = repoEf.GetAllItems().ToArray();
            return items;
        }

        public Item GetItem(int id)
        {
            return repoEf.GetItem(id);
        }

        public string GetItemTitle(int id)
        {
            Item item = repoEf.GetItem(id);
            return item.Title;
        }

        public string getText()
        {
            return "Text from server";
        }

        public void ItemAdded(string item)
        {
            Console.WriteLine(item);
        }

        public void ItemDeleted(int id)
        {
            Console.WriteLine("Deleted item id = {0}",id);
        }

        public void ItemsFromDatabase(string ItemsString)
        {
            Console.WriteLine(ItemsString);
        }

        public void ItemUpdated(int id, string newTitle)
        {
            Console.WriteLine("Updated item id = {0}, new Title = {1}", id,newTitle);
        }

        public void Update(Item item)
        {
            repoEf.Create(item);
        }
    }
}
