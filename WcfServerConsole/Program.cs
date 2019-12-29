using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WCFServiceLib;
using System.Net.Sockets;
using System.Net;
using WCFServiceLibDto;

namespace WcfServerConsole
{
    class Program
    {
        static void StartWcf() 
        {
            Task[] tasks = new Task[2] 
            {
                new Task(()=>
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                }),
                new Task(()=>
                {
                try
                {
                    ServiceHost host = new ServiceHost(typeof(ItemDTOService));

                    host.Open();
                    Console.WriteLine("Hosted dto service");
                    
                    Console.Read();
                    host.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                })
            };
            foreach(var t in tasks) 
            {
                t.Start();
            }
            Task.WaitAll(tasks);

        }
        static void Main(string[] args)
        {
            StartWcf();
        }
    }
}
