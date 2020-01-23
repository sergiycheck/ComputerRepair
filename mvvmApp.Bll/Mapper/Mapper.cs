using AutoMapper;
using mvvmApp.Dal.Abstract;
using mvvmApp.Dal.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServiceLibDto.DTOs;

namespace mvvmApp.Bll.Mapper
{
    public class Mapper
    {
        public Mapper() 
        {

        }
        public  Item Convert(ItemDTO DtoItem)
        {
            var mapperConf = new MapperConfiguration(config =>
            {
                config.CreateMap<ItemDTO, Item>();
                config.CreateMap<OrderDTO, Order>();
                config.CreateMap<DetailDTO, Detail>();
            });
            var mapper = mapperConf.CreateMapper();
            var item = mapper.Map<ItemDTO, Item>(DtoItem);
            return item;
        }
        public  ItemDTO Convert(Item Item)
        {
            var mapperConf = new MapperConfiguration(config =>
            {
                config.CreateMap<Item, ItemDTO>();
                config.CreateMap<Order, OrderDTO>();
                config.CreateMap<Detail, DetailDTO>();
            });
            var mapper = mapperConf.CreateMapper();
            var itemDTO = mapper.Map<Item, ItemDTO>(Item);
            return itemDTO;
        }
        public  List<ItemDTO> ConvertList(List<Item> items)
        {
            var mapperConf = new MapperConfiguration(config =>
            {
                config.CreateMap<Item, ItemDTO>();
                config.CreateMap<Order, OrderDTO>();
                config.CreateMap<Detail, DetailDTO>();
            });
            var mapper = mapperConf.CreateMapper();
            var Dtoitems = mapper.Map<List<Item>, List<ItemDTO>>(items);
            return Dtoitems;
        }
        public  Order Convert(OrderDTO orderDTO)
        {
            var mapperConf = new MapperConfiguration
                (config =>
                {
                    config.CreateMap<ItemDTO, Item>();
                    config.CreateMap<OrderDTO, Order>();
                    //.ForMember(dest => dest.ItemOrders, opt => opt.MapFrom(src => src.OrderedComputers)); 
                    config.CreateMap<DetailDTO, Detail>();
                });
            var mapper = mapperConf.CreateMapper();
            var order = mapper.Map<OrderDTO, Order>(orderDTO);
            return order;
        }
        public  OrderDTO Convert(Order order)
        {
            var mapperConf = new MapperConfiguration
                (config =>
                {
                    config.CreateMap<Item, ItemDTO>();
                    config.CreateMap<Order, OrderDTO>();
                    config.CreateMap<Detail, DetailDTO>();
                });
            var mapper = mapperConf.CreateMapper();
            var orderDTO = mapper.Map<Order, OrderDTO>(order);
            return orderDTO;
        }
        public  List<OrderDTO> Convert(List<Order> orderList)
        {
            var mapperConf = new MapperConfiguration
                (config =>
                {
                    config.CreateMap<Item, ItemDTO>();
                    config.CreateMap<Order, OrderDTO>();
                    config.CreateMap<Detail, DetailDTO>();
                });
            var mapper = mapperConf.CreateMapper();
            var orderDtoList = mapper.Map<List<Order>, List<OrderDTO>>(orderList);
            return orderDtoList;
        }
    }
}
