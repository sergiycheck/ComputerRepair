using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WCFServiceLib;
using System.Net.Sockets;
using System.Net;

namespace WcfServerConsole
{
    class Program
    {
        static void StartWcf() 
        {
            try 
            {
                //Uri baseAddress = new Uri("http://localhost:8733/Design_Time_Addresses/WCFServiceLib/ItemService/");
                ServiceHost host = new ServiceHost(typeof(ItemService));


                host.Open();
                Console.WriteLine("Hosted");
                Console.Read();
                host.Close();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            StartWcf();
        }
    }
}
