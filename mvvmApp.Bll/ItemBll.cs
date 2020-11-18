using mvvmApp.Dal.Abstract;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract.Repositories;
using System.Collections.Generic;
using System.Linq;
using DTOs;

namespace mvvmApp.Bll
{
    public class ItemBll
    {
        private readonly Mapper.Mapper Mapper;
        private readonly ItemRepository<Item> repository;
        
        public ItemBll() 
        {
            repository = new ItemRepository<Item>(ApplicationContext.GetInstance());
            Mapper = new Mapper.Mapper();
        }
        public ItemBll(string connectionString)
        {
            repository = new ItemRepository<Item>(
                new ApplicationContext(connectionString));
            Mapper = new Mapper.Mapper();
        }

        public void Create(ItemDTO elem)
        {
            repository.Create(Mapper.Convert(elem));
        }

        //difference between item from automapper and entityFramework is that 
        //collection properties of item are initialized with 0 count by automapper 
        // but entity framework set collection properties to null on retrieving withot include 
        public void Delete(ItemDTO elemDto)
        {
            var item = repository.GetById(elemDto.Id);
            repository.Delete(item);
        }

        public ItemDTO Get(int id)
        {
            var item = repository.GetById(id);
            return Mapper.Convert(item);
        }

        public List<ItemDTO> GetAll()
        {
            List<ItemDTO> items = Mapper.ConvertList(repository.GetAll().ToList());
            return items;
        }

        public void Update(ItemDTO elemDto)
        {
            var elem = Mapper.Convert(elemDto);
            repository.Update(elem);
            
        }
    }
}
