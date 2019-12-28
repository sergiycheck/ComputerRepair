using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServiceLib.DTOs;
using mvvmApp.Dal.Abstract.Repositories;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract;
using AutoMapper;

namespace WCFServiceLib
{
    public class ItemServiceDto : IItemServiceDto
    {
        ItemRepository<Item> repository;
        public ItemServiceDto()
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
            var mapperConf = new MapperConfiguration(config => config.CreateMap<List<Item>, List<ItemDTO>>());
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
