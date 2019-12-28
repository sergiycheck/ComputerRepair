using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFServiceLib.DTOs;

namespace WCFServiceLib
{
    [ServiceContract]
    interface IItemServiceDto
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
