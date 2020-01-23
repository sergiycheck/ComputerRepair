using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceLibDto.DTOs;

namespace WCFServiceLibDto
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IItemDTOService" in both code and config file together.
    [ServiceContract]
    interface IDTOService
    {
        [OperationContract]
        void CreateItem(ItemDTO elem, DetailDTO detail);

        [OperationContract]
        void UpdateItem(ItemDTO elem);

        [OperationContract]
        void DeleteItem(ItemDTO elem);

        [OperationContract]
        ItemDTO GetItem(int id);

        [OperationContract]
        OrderDTO GetOrder(int id);

        [OperationContract]
        List<ItemDTO> GetAllItem();

        [OperationContract]
        void CreateOrder(OrderDTO orderDTO);

        [OperationContract]
        List<OrderDTO> GetOrderedComputers();

    }
}
