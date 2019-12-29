using System.Collections.Generic;
using System.Linq;
using WCFServiceLibDto.DTOs;
using mvvmApp.Dal.Abstract.Repositories;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract;
using AutoMapper;

namespace WCFServiceLibDto
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ItemDTOService" in both code and config file together.
    public class ItemDTOService : IItemDTOService
    {
        ItemRepository<Item> repository;
        public ItemDTOService()
        {
            repository = new ItemRepository<Item>(new ApplicationContext("mvvmApp.Dal.Abstract.Entities.ApplicationContext"));
        }
        private Item convert(ItemDTO DtoItem)
        {
            var mapperConf = new MapperConfiguration(config => config.CreateMap<ItemDTO, Item>());
            var mapper = mapperConf.CreateMapper();
            var item = mapper.Map<ItemDTO, Item>(DtoItem);
            return item;
        }
        private List<ItemDTO> convertList(List<Item> items)
        {
            var mapperConf = new MapperConfiguration(config => config.CreateMap<Item, ItemDTO>());
            var mapper = mapperConf.CreateMapper();
            var Dtoitems = mapper.Map<List<Item>, List<ItemDTO>>(items);
            return Dtoitems;
        }
        public void Create(ItemDTO elem)
        {
            repository.Create(convert(elem));
        }

        public void Delete(ItemDTO elem)
        {
            repository.Delete(convert(elem));
        }

        public void Get(int id)
        {
            repository.GetById(id);
        }

        public List<ItemDTO> GetAll()
        {
            return convertList(repository.GetAll().ToList());
        }

        public void Update(ItemDTO elem)
        {
            repository.Update(convert(elem));
        }
    }
}
