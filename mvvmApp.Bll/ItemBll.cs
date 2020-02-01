using mvvmApp.Dal.Abstract;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTOs;
using mvvmApp.Bll.Mapper;

namespace mvvmApp.Bll
{
    public class ItemBll
    {
        Mapper.Mapper Mapper;
        ItemRepository<Item> repository;
        public ItemBll() 
        {
            repository = new ItemRepository<Item>
            (
            new ApplicationContext
            ("mvvmApp.Dal.Abstract.Entities.ApplicationContext")
            );
            Mapper = new Mapper.Mapper();
        }
        public void Create(ItemDTO elem)
        {
            repository.Create(Mapper.Convert(elem));
        }

        public void Delete(ItemDTO elem)
        {
            repository.Delete(Mapper.Convert(elem));
        }

        public ItemDTO Get(int id)
        {
            return Mapper.Convert(repository.GetById(id));
        }

        public List<ItemDTO> GetAll()
        {
            List<ItemDTO> items = Mapper.ConvertList(repository.GetAll().ToList());
            return items;
        }

        public void Update(ItemDTO elem)
        {
            repository.Update(Mapper.Convert(elem));
        }
    }
}
