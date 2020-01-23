using System;
using System.Collections.Generic;
using System.Linq;
using TestRepoConsoleApp.DTOServiceReference;


namespace TestRepoConsoleApp
{
    class Program
    {

        static void TestDTOService() 
        {
            try
            {
                DTOServiceClient client = new DTOServiceClient("BasicHttpBinding_IDTOService");
                List<ItemDTO> itemDTOs = client.GetAllItem().ToList();
                foreach(var i in itemDTOs) 
                {
                    Console.WriteLine(i.Company + " ");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            TestDTOService();
        }
    }
}
