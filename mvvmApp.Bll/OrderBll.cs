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
            repository = new OrderRepository<Order>
                (
                new ApplicationContext
                ("mvvmApp.Dal.Abstract.Entities.ApplicationContext")
                );
            Mapper = new Mapper.Mapper();
        }

        public void Create(OrderDTO orderDTO) 
        {
            try
            {
                repository.Create(Mapper.Convert(orderDTO));
            }
            catch (Exception ex)
            {


            }
            
        }
        
        public OrderDTO Get(int id)
        {
            return Mapper.Convert(repository.GetById(id));
        }
        public List<ItemDTO> GetOrderWithComputers()
        {
            try
            {
                var orders = Mapper.Convert(repository.GetAll().ToList());
                List<ItemDTO> items = new List<ItemDTO>();
                foreach(var o in orders)
                {
                    foreach(var i in o.OrderedComputers) 
                    {
                        items.Add(i);
                    }
                }
                return items;
                //return Mapper.Convert(repository.GetOrdersWithComputers());
            }
            catch (Exception ex)
            {

               
            }
            return null;
        }
        public void Delete(OrderDTO orderDTO) 
        {
            repository.Delete(Mapper.Convert(orderDTO));
        }
    }
}
