using System;
using System.Collections.Generic;
using System.Linq;
//using mvvmApp.Dal.Abstract;
//using mvvmApp.Dal.Abstract.Entities;
//using mvvmApp.Dal.Abstract.Repositories;
//using TestRepoConsoleApp.ServiceReference1;

namespace TestRepoConsoleApp
{
    class Program
    {
        //static void TestOrders()
        //{
        //    OrderRepositoryADO ordersRepo = new OrderRepositoryADO();
        //    List<Item> items = new List<Item>();
        //    items = ordersRepo.GetOrderedItems(1002).ToList();
        //    Console.WriteLine("Ordered items by User with id = {0}",1002);
        //    foreach (var VARIABLE in items)
        //    {
        //        Console.WriteLine(VARIABLE.ToString());
        //    }
        //}

        //static void TestItems()
        //{
        //    ItemRepositoryADO computersRepo = new ItemRepositoryADO();
        //    List<Item> computers = new List<Item>(computersRepo.GetAllItems());
        //    Console.WriteLine("All Items ");
        //    foreach (var VARIABLE in computers)
        //    {
        //        Console.WriteLine(VARIABLE.ToString());
        //    }
        //}
        //static void TestServerTcp()
        //{
        //    ItemRepositoryADO computersRepo = new ItemRepositoryADO();
        //    List<Item> Items = new List<Item> 
        //    { 
        //        new Item
        //        {
        //            Company = "Company Server",
        //            ImagePath = @"D:\Photos\image.jpg",
        //            Price = 100,
        //            Title = "server succsess"
        //        }
        //    };

        //    computersRepo.SendToServer
        //        (
        //        new Order
        //        {
        //            Address = "address",
        //            Date = DateTime.Now,
        //            PhoneNumber = "380978674483",
        //            Sum = 100,
        //            OrderedComputers = Items
        //        }

        //        );
        //}
        static void TestWcfServer() 
        {
            try 
            {
                //ItemServiceClient client = new ItemServiceClient();
                //string text = client.getText();
                //Console.WriteLine(text);
                //Item[] items = client.GetAllItems();

            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }


        }
        static void Main(string[] args)
        {
            //TestOrders();
            //TestItems();
            //TestServerTcp();
            TestWcfServer();
        }
    }
}
