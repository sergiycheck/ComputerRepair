using System.Collections.Generic;
using System.Linq;

using mvvmApp.Dal.Abstract.Repositories;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract;
using AutoMapper;
using WCFServiceLibDto.DTOs;
using mvvmApp.Bll;

namespace WCFServiceLibDto
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ItemDTOService" in both code and config file together.
    public class DTOService : IDTOService
    {
        private static OrderBll orderBll = new OrderBll();
        private static ItemBll itemBll = new ItemBll();
        public DTOService()
        {
            
        }

        public void CreateItem(ItemDTO elem, DetailDTO detail)
        {
            
            itemBll.Create(elem);
        }

        public void CreateOrder(OrderDTO orderDTO)
        {
            
            orderBll.Create(orderDTO);
        }

        public void DeleteItem(ItemDTO elem)
        {
            
            itemBll.Delete(elem);
        }

        public ItemDTO GetItem(int id)
        {
            
            return itemBll.Get(id);
        }
        public OrderDTO GetOrder(int id)
        {
            
            return orderBll.Get(id);
        }

        public List<ItemDTO> GetAllItem()
        {
            
            return itemBll.GetAll();
        }

        public List<OrderDTO> GetOrderedComputers()
        {
            return orderBll.GetOrderWithComputers();
        }

        public void UpdateItem(ItemDTO elem)
        {
            itemBll.Update(elem);
        }
    }
}
