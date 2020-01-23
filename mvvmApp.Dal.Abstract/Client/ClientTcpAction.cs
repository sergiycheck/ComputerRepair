using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace mvvmApp.Dal.Abstract.Client
{
    public class ClientTcpAction
    {
        TcpClient client;
        IPAddress addr;
        public ClientTcpAction() 
        {
            
            if(IPAddress.TryParse("127.0.0.1", out addr))
                client = new TcpClient();
        }
        public void SendData<T>(T elem) 
        {
            client.Connect(addr, 8888);
            BinaryFormatter binary = new BinaryFormatter();
            using(var stream = client.GetStream()) 
            {
                binary.Serialize(stream, elem);
            }
        }
    }
}
