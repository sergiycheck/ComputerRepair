using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract;
using AutoMapper;
using WCFServiceLibDto.DTOs;
using mvvmApp.Dal.Abstract.Repositories;
using System.Data.Entity;

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
        public List<OrderDTO> GetOrderWithComputers()
        {
            try
            {
                return Mapper.Convert(repository.Context.Orders.Include(o => o.ItemOrders).ToList());
            }
            catch (Exception ex)
            {

               
            }
            return null;
        }
    }
}
