using mvvmApp.Dal.Abstract;
using mvvmApp.Dal.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TcpServer
{
    public class ServerTcp
    {
        TcpListener listener;
        public Item Item {get;set; }
        public Order Order { get; set; }
        public User User { get; set; }
        private ServerRepoManager manag;
        public ServerTcp() 
        {
            IPAddress localAddr;
            localAddr = IPAddress.Parse("127.0.0.1");
            listener = new TcpListener(localAddr,8888);
            listener.Start();
            manag = new ServerRepoManager();
            while (true) 
            {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                Console.WriteLine("Listener started");
#pragma warning restore CA1303 // Do not pass literals as localized parameters

                TcpClient client = listener.AcceptTcpClient();
                BinaryFormatter binFormat = new BinaryFormatter();
                
                using (NetworkStream stream = client.GetStream()) 
                {
                    object obj = binFormat.Deserialize(stream);
                    try
                    {
                        switch (obj.GetType().ToString())
                        {
                            case "mvvmApp.Dal.Abstract.Item":
                                Item = obj as Item;
                                Console.WriteLine("Item = {0}", Item.ToString());
                                manag.CreateItem(Item);
                                break;
                            case "mvvmApp.Dal.Abstract.Order":
                                Order = obj as Order;
                                Console.WriteLine("Order = {0}, ordered computers = {1}", Order.ToString(),Order.OrderedComputers.First().ToString());
                                manag.CreateOrder(Order);
                                break;
                            case "mvvmApp.Dal.Abstract.Entities.User":
                                User = obj as User;
                                Console.WriteLine("User = {0}", User.ToString());
                                manag.CreateUser(User);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception = {0}", ex.Message.ToString());
                    }
                }
                 
            }
            


        }
        //public void GetData() 
        //{

            

        //}
        public void Stop() 
        {
            if (listener != null)
                listener.Stop();
        }
    }
}
