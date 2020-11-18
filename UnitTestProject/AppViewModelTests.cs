using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Linq;
using DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using mvvmapp;
//using mvvmapp.DTOServiceReference;
using mvvmapp.ViewModels;
using mvvmApp.Bll;
using mvvmApp.Bll.Mapper;
using mvvmApp.Dal.Abstract;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract.Repositories;

//using UnitTestProject.DTOServiceReference;



namespace UnitTestProject
{
    [TestClass]
    public class AppViewModelTests
    {
        private ItemBll _itemService;
        private ApplicationContext _context;
        private string _connectionString;
        private Mapper _mapper;
        private OrderBll _orderService;
        private DetailBll _detailService;

        public AppViewModelTests() 
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ComputerRepairDbConnection"].ConnectionString;
            _itemService = new ItemBll(_connectionString);
            _orderService = new OrderBll();
            _detailService = new DetailBll();
            _context = ApplicationContext.GetInstance();
            _mapper = new Mapper();
        }
        [TestMethod]
        //TODO make orders working

        //https://social.msdn.microsoft.com/Forums/en-US/62a83af0-26bf-4608-85cc-fe59aab8a730/update-detached-entity-in-ef-6?forum=adodotnetentityframework
        //https://stackoverflow.com/questions/8292149/load-can-only-be-called-when-the-entitycollection-or-entityreference-does-not-co

        //disabled dynamic proxy (expecting include method)
        public void TestItemUpdate() 
        {
            var id = 1;
            var rnd = new Random();
            var newTitle = $"ChangedTitle{rnd.Next(0,1000)}";
            var item = _itemService.Get(id);
            item.Title = newTitle;
            _itemService.Update(item);
            var updatedItem = _context.Items.AsNoTracking().FirstOrDefault(i => i.Id == id);
            Assert.AreEqual(newTitle, updatedItem.Title);
        }
        [TestMethod]
        public void TestGetAll() 
        {
            var items = _itemService.GetAll();
            var count = _context.Items.AsNoTracking().Count();
            Assert.IsNotNull(items);
            Assert.AreEqual(count, items.Count);
        }
        [TestMethod]
        public void IsMappingItemsToObservableCollection()
        {
            var observItemsList = 
                _mapper.ConvertList(_itemService.GetAll());
            var typeExpected = typeof(ObservableCollection<ItemModel>);
            var typeActual = observItemsList.GetType();
            Assert.AreEqual(typeExpected, typeActual);
        }
        public Item CreateNewItem(ItemDTO newItem) 
        {
            _itemService.Create(newItem);
            var createdItem = _context.Items.AsNoTracking().Where(i => i.Title == newItem.Title).FirstOrDefault();
            Assert.IsNotNull(createdItem);
            return createdItem;
        }
        public ItemDTO GetItemDTO()
        {
            return new ItemDTO()
            {
                Company = "TestComp",
                ImagePath = "\\",
                Title = "TestPrice",
                Price = 1234
            };
            
        }
        [TestMethod]
        public void DeleteItem() 
        {
            var newItem = GetItemDTO();
            var createdItem = CreateNewItem(newItem);

            _itemService.Delete(_mapper.Convert(createdItem));
            var deletedItem = _context.Items.AsNoTracking().FirstOrDefault(i => i.Id == createdItem.Id);
            Assert.IsNull(deletedItem);
        }
        [TestMethod]
        public void MakeOrderWithIncludedItems() 
        {
            
            var orderWithComputers = _orderService.GetOrderWithComputers();
            
            if (orderWithComputers == null || orderWithComputers.Count==0)
            {
                var rnd = new Random();
                var orderedComputers = _itemService.GetAll();
                if(orderedComputers==null)
                    orderedComputers = new List<ItemDTO>()
                    {
                        GetItemDTO()
                    };
                var orderDTO = new OrderDTO()
                {
                    Address = $"TestAddress{rnd.Next(0, 100)}",
                    Date = DateTime.Now,
                    PhoneNumber = $"+380{rnd.Next(0, 1000000000)}",
                    Sum = rnd.Next(0, 100),
                    OrderedComputers = orderedComputers
                };
            
                _orderService.Create(orderDTO);
                orderWithComputers = _orderService.GetOrderWithComputers();
            }
            
            var order = orderWithComputers.FirstOrDefault();
            var orderId = order.Id;

            var item = order.OrderedComputers.FirstOrDefault();
            var itemId = item.Id;
            var initialCountOfComputersInOrder = order.OrderedComputers.Count();
            _orderService.DeleteItemFromOrder(itemId, orderId);
            var updatedOrder = _orderService.GetOrderWithComputers();
            Assert.AreEqual(initialCountOfComputersInOrder - 1, updatedOrder.Count());
            
        }

    }
}
