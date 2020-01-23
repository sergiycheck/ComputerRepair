using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using System.Net.Sockets;
using System.Net;
using WCFServiceLibDto;

namespace WcfServerConsole
{
    class Program
    {
        static void StartWcf() 
        {
            ServiceHost host = new ServiceHost(typeof(DTOService));

            host.Open();
            Console.WriteLine("WCF DtoService hosted");

            Console.Read();
            host.Close();


        }
        static void Main(string[] args)
        {
            StartWcf();
        }
    }
}
