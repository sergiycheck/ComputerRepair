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
    interface IItemDTOService
    {
        [OperationContract]
        void Create(ItemDTO elem);

        [OperationContract]
        void Update(ItemDTO elem);

        [OperationContract]
        void Delete(ItemDTO elem);

        [OperationContract]
        void Get(int id);
        [OperationContract]
        List<ItemDTO> GetAll();
    }
}
