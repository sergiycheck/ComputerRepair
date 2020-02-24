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

        public List<DetailDTO> Convert(List<Detail> list)
        {
            var mapperConf = new MapperConfiguration(config =>
            {
                config.CreateMap<Item, ItemDTO>();
                config.CreateMap<Order, OrderDTO>();
                config.CreateMap<Detail, DetailDTO>();
            });
            var mapper = mapperConf.CreateMapper();
            var Dtodetails = mapper.Map<List<Detail>, List<DetailDTO>>(list);
            return Dtodetails;

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
            MapperConfiguration mapperConf = null;
            List<ItemModel> ItemModels = new List<ItemModel>();

            foreach (var item in itemDTOs) 
            {
                
                if (item.Orders.Count == 0) 
                {
                    mapperConf = new MapperConfiguration
                    (config =>
                    {
                        config.CreateMap<ItemDTO, ItemModel>().MaxDepth(4);
                        config.CreateMap<OrderDTO, OrderModel>().MaxDepth(4);
                        config.CreateMap<DetailDTO, DetailModel>().MaxDepth(4);
                        config.CreateMap<List<ItemDTO>, ObservableCollection<ItemModel>>();
                        config.CreateMap< List<OrderDTO>, ObservableCollection<OrderModel> > ();
                        config.CreateMap< List<DetailDTO>, ObservableCollection<DetailModel> > ();
                    });
                }
                else 
                {
                    mapperConf = new MapperConfiguration
                    (config =>
                    {
                        config.CreateMap<ItemDTO, ItemModel>();//.MaxDepth(1);
                        config.CreateMap<OrderDTO, OrderModel>();//.MaxDepth(1);
                        config.CreateMap<DetailDTO, DetailModel>();//.MaxDepth(1);
                        config.CreateMap<List<ItemDTO>, OrderModel>()
                        .ForMember(dest => dest.OrderedComputers, opt => opt.MapFrom(src => src));
                        config.CreateMap<List<OrderDTO>, ItemModel>()
                        .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src));
                        //.AfterMap((src,dest)=>AutoMapper.Mapper.Map(src,dest.Orders));
                        config.CreateMap<List<DetailDTO>, ItemModel>()
                        .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src));
                        //config.CreateMap<OrderDTO, ObservableCollection<ItemModel>>().MaxDepth(4)
                        //.ForMember(dest => dest, opt => opt.MapFrom(src => src.OrderedComputers));
                        //config.CreateMap<ItemDTO, ObservableCollection<OrderModel>>().MaxDepth(4)
                        //.ForMember(dest => dest, opt => opt.MapFrom(src => src.Orders));

                    });
                }
                var mapper = mapperConf.CreateMapper();
                var ItemModel = mapper.Map<ItemDTO, ItemModel>(item);
                ItemModels.Add(ItemModel);
            }

            return new ObservableCollection<ItemModel>(ItemModels);
        }
        public ObservableCollection<OrderModel> ConvertList(List<OrderDTO> orderDTOs)
        {
            var mapperConf = new MapperConfiguration
                (config =>
                {
                    config.CreateMap<ItemDTO, ItemModel>().MaxDepth(4);
                    config.CreateMap<OrderDTO, OrderModel>().MaxDepth(4);
                    config.CreateMap<DetailDTO, DetailModel>().MaxDepth(4);
                    config.CreateMap<List<OrderDTO>, ItemModel>().MaxDepth(4)
                    .ForMember(dest=>dest.Orders, opt=>opt.MapFrom(src=>src));
                    config.CreateMap<List<ItemDTO>, OrderModel>().MaxDepth(4)
                    .ForMember(dest => dest.OrderedComputers, opt => opt.MapFrom(src => src));
                    config.CreateMap<List<DetailDTO>, ItemModel>().MaxDepth(4)
                    .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src));
                });
            var mapper = mapperConf.CreateMapper();
            var OrderModels = mapper.Map<List<OrderDTO>, List<OrderModel>>(orderDTOs);
            return new ObservableCollection<OrderModel>(OrderModels);
        }

        public ObservableCollection<DetailModel> ConvertList(List<DetailDTO> detailDtos)
        {
            var mapperConf = new MapperConfiguration
            (config =>
            {
                config.CreateMap<ItemDTO, ItemModel>().MaxDepth(4);
                config.CreateMap<OrderDTO, OrderModel>().MaxDepth(4);
                config.CreateMap<DetailDTO, DetailModel>().MaxDepth(4);
                config.CreateMap<List<OrderDTO>, ItemModel>().MaxDepth(4)
                    .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src));
                config.CreateMap<List<ItemDTO>, OrderModel>().MaxDepth(4)
                    .ForMember(dest => dest.OrderedComputers, opt => opt.MapFrom(src => src));
                config.CreateMap<List<DetailDTO>, ItemModel>().MaxDepth(4)
                    .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src));
            });
            var mapper = mapperConf.CreateMapper();
            var DetailModels = mapper.Map<List<DetailDTO>, List<DetailModel>>(detailDtos);
            return new ObservableCollection<DetailModel>(DetailModels);
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
