using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using mvvmApp.Dal.Abstract;
namespace WCFServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IItemService" in both code and config file together.
    [ServiceContract]
    public interface IItemService
    {

        [OperationContract]
        string getText();
        [OperationContract]
        string GetItemTitle(int id);

        [OperationContract]
        void ItemsFromDatabase(string ItemsString);
        [OperationContract]
        void ItemUpdated(int id, string newTitle);
        [OperationContract]
        void ItemDeleted(int id);
        [OperationContract]
        void ItemAdded(string item);
        [OperationContract]
        Item GetItem(int id);
    }
}
