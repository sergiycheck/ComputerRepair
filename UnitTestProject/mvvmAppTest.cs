using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using mvvmapp;
using mvvmapp.DTOServiceReference;
using mvvmapp.ViewModels;
using mvvmApp.Bll;
using mvvmApp.Dal.Abstract;
using mvvmApp.Dal.Abstract.Repositories;

//using UnitTestProject.DTOServiceReference;



namespace UnitTestProject
{
    [TestClass]
    public class mvvmAppTest
    {
        ApplicationViewModel app;
        ObservableCollection<ItemModel> Computers;
        public mvvmAppTest() 
        {
            app = new ApplicationViewModel(); 
        }
        [TestMethod]
        public void CheckGetItemModelsMapping()
        {
             
            ItemBll itemBll = new ItemBll();
            Computers =  app.GetItemModels(
                new List<ItemDTO>() 
                {
                    new ItemDTO() { Company = "test", Details = null, Id=0, ImagePath = "", Orders = new OrderDTO[1]{ new OrderDTO()}, Price = 100, Title = ""  }
                }
                );
            Assert.IsNotNull(Computers);

        }
        [TestMethod]
        public void TestGetItemModels() 
        {
            app.clientDto = new DTOServiceClient("BasicHttpBinding_IDTOService");

            List<ItemDTO> itemDTOs = new List<ItemDTO>(app.clientDto.GetAllItem());//get all items
            Computers = app.GetItemModels(itemDTOs);
            Assert.IsNotNull(Computers);
            Assert.AreEqual("Macbook", itemDTOs.First().Title);
        }
        [TestMethod]
        public void testRepo() 
        {
            ItemBll itemBll = new ItemBll();
            WCFServiceLibDto.DTOs.ItemDTO itemDTO = itemBll.Get(4);
            Assert.IsNotNull(itemDTO);

            itemDTO.Company = "MSi Updated";
            itemBll.Update(itemDTO);


        }
    }
}
