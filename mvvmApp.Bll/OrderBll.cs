using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract;
using AutoMapper;

using mvvmApp.Dal.Abstract.Repositories;
using System.Data.Entity;
using DTOs;

namespace mvvmApp.Bll
{
    
    public class OrderBll
    {
        Mapper.Mapper Mapper;
        OrderRepository<Order> repository;
        public OrderBll() 
        {
            repository = new OrderRepository<Order>(ApplicationContext.GetInstance());
            Mapper = new Mapper.Mapper();
        }

        public void Create(OrderDTO orderDTO) 
        {
            try
            {
                List<Item> items = new List<Item>();
                Order order = Mapper.Convert(orderDTO);
                //order.OrderedComputers = new List<Item>();
                //foreach (var item in orderDTO.OrderedComputers)
                //{
                //    var itemFromDb = repository.Context.Items.AsNoTracking().FirstOrDefault(i => i.Id == item.Id);
                //    itemFromDb.Orders.Add(order);
                //    items.Add(itemFromDb);
                //}

                //order.OrderedComputers = items;

                repository.Create(order);
            }
            catch (Exception ex)
            {


            }
            
        }
        
        public OrderDTO Get(int id)
        {
            return Mapper.Convert(repository.GetById(id));
        }
        public List<OrderDTO> GetOrderWithComputers()
        {
            try
            {
                var orders = Mapper.Convert(repository.GetOrdersWithComputers());
                return orders;//Mapper.Convert(repository.GetAll().ToList());
            }
            catch (Exception ex)
            {

               
            }
            return null;
        }
        public void DeleteItemFromOrder(int itemId, int? orderId)
        {
            var orders = repository.GetOrdersWithComputers();
            foreach (var order in orders)
            {
                if (order.Id == orderId)
                {
                    foreach (var item in order.OrderedComputers)
                    {
                        if (item.Id == itemId)
                        {
                            order.OrderedComputers.Remove(item);
                            repository.Update(order);
                            break;
                        }
                    }
                    
                }

            }
            

        }
    }
}
