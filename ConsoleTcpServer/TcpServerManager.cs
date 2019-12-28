using mvvmApp.Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpServer;
using System.ServiceModel;

namespace ConsoleTcpServer
{
    public class TcpServerManager
    {
        ServerTcp server;
        public TcpServerManager()
        {
            server = new ServerTcp();
        }
        public Item Item 
        {
            get 
            {
                //server.GetData();
                return server.Item;
            }
        }
    }
}
