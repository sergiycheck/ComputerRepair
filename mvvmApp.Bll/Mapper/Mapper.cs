using AutoMapper;
using Models;
using mvvmApp.Dal.Abstract;
using mvvmApp.Dal.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace mvvmApp.Bll.Mapper
{
    public class Mapper
    {
        public Mapper()
        {

        }
        public Item Convert(ItemDTO DtoItem)
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

        public User Convert(UserDTO user)
        {
            var mapperConf = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDTO, User>();
                config.CreateMap<OrderDTO, Order>();
                config.CreateMap<DetailDTO, Detail>();
                config.CreateMap<ItemDTO, Item>();
            });
            var mapper = mapperConf.CreateMapper();
            var userDTO = mapper.Map<UserDTO, User>(user);
            return userDTO;
        }

        public ItemDTO Convert(Item Item)
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
        public ItemDTO Convert(ItemModel Item)
        {
            var mapperConf = new MapperConfiguration(config =>
            {
                config.CreateMap<ItemModel, ItemDTO>();
                config.CreateMap<OrderModel, OrderDTO>();
                config.CreateMap<DetailModel, DetailDTO>();
            });
            var mapper = mapperConf.CreateMapper();
            var itemDTO = mapper.Map<ItemModel, ItemDTO>(Item);
            return itemDTO;
        }
        public List<ItemDTO> ConvertList(List<Item> items)
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
        public Order Convert(OrderDTO orderDTO)
        {
            var mapperConf = new MapperConfiguration
                (config =>
                {
                    config.CreateMap<ItemDTO, Item>();
                    config.CreateMap<OrderDTO, Order>(); 
                    config.CreateMap<DetailDTO, Detail>();
                });
            var mapper = mapperConf.CreateMapper();
            var order = mapper.Map<OrderDTO, Order>(orderDTO);
            return order;
        }
        public ObservableCollection<ItemModel> ConvertList(List<ItemDTO> itemDTOs)
        {
            var mapperConf = new MapperConfiguration
                (config =>
                {
                    config.CreateMap<ItemDTO, ItemModel>();
                    config.CreateMap<OrderDTO, OrderModel>();
                    config.CreateMap<DetailDTO, DetailModel>();
                });
            var mapper = mapperConf.CreateMapper();
            var ItemModels = mapper.Map<List<ItemDTO>, ObservableCollection<ItemModel>>(itemDTOs);
            return ItemModels;
        }
        public ObservableCollection<OrderModel> ConvertList(List<OrderDTO> orderDTOs)
        {
            var mapperConf = new MapperConfiguration
                (config =>
                {
                    config.CreateMap<ItemDTO, ItemModel>();
                    config.CreateMap<OrderDTO, OrderModel>();
                    config.CreateMap<DetailDTO, DetailModel>();
                });
            var mapper = mapperConf.CreateMapper();
            var OrderModels = mapper.Map<List<OrderDTO>, ObservableCollection<OrderModel>>(orderDTOs);
            return OrderModels;
        }
        public ItemModel ConvertToModel(ItemDTO itemDTO)
        {
            var mapperConf = new MapperConfiguration
                (config =>
                {
                    config.CreateMap<ItemDTO, ItemModel>();
                    config.CreateMap<OrderDTO, OrderModel>();
                    config.CreateMap<DetailDTO, DetailModel>();
                });
            var mapper = mapperConf.CreateMapper();
            var ItemModel = mapper.Map<ItemDTO, ItemModel>(itemDTO);
            return ItemModel;
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
        public OrderDTO Convert(OrderModel order)
        {
            var mapperConf = new MapperConfiguration
                (config =>
                {
                    config.CreateMap<ItemModel, ItemDTO>();
                    config.CreateMap<OrderModel, OrderDTO>();
                    config.CreateMap<DetailModel, DetailDTO>();
                });
            var mapper = mapperConf.CreateMapper();
            var orderDTO = mapper.Map<OrderModel, OrderDTO>(order);
            return orderDTO;
        }
        public List<OrderDTO> ConvertList(ObservableCollection<OrderModel> orders)
        {
            var mapperConf = new MapperConfiguration
                (config =>
                {
                    config.CreateMap<ItemModel, ItemDTO>();
                    config.CreateMap<OrderModel, OrderDTO>();
                    config.CreateMap<DetailModel, DetailDTO>();
                });
            var mapper = mapperConf.CreateMapper();
            var orderDTOs = mapper.Map<ObservableCollection<OrderModel>, List<OrderDTO>>(orders);
            return orderDTOs;
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
