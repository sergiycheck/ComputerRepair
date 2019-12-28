using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using mvvmapp.Models;
using mvvmApp.Bll.Intecation.Commands;
using mvvmApp.Bll.Infrastructure;
using mvvmApp.Dal.Abstract.Repositories;//DAL
using System.Runtime.CompilerServices;
using mvvmApp.Dal.Abstract.Client;
using mvvmApp.Dal.Abstract;
using mvvmApp.Dal.Abstract.Entities;
using System.Windows;

namespace mvvmapp.ViewModels
{
    public class OrderViewModel : OrderModel
    {
        private ClientTcpAction client = new ClientTcpAction();
        private ItemModel selectedOrderedComputer;
        private OrderRepository<Order> orderRepo;


        public ItemModel SelectedOrderedComputer
        {
            get
            {
                return selectedOrderedComputer;
            }
            set
            {
                selectedOrderedComputer = value;
                OnPropertyChanged("SelectedOrderedComputer");
            }

        }
        private RelayCommand deleteOrderedComputerCommand;
        public RelayCommand DeleteOrderedComputerCommand
        {
            get
            {
                if (deleteOrderedComputerCommand != null)
                    return deleteOrderedComputerCommand;
                else
                    return (deleteOrderedComputerCommand = new RelayCommand(ob =>
                    {
                        ItemModel item = ob as ItemModel;
                        if (ob != null)
                        {
                            OrderedComputers.Remove(item);

                        }

                    },
                    (ob) => OrderedComputers.Count > 0
                    ));
            }
        }
        private RelayCommand makeOrderCommand;
        public RelayCommand MakeOrderCommand
        {
            get
            {
                if (makeOrderCommand != null)
                    return makeOrderCommand;
                else
                    return (makeOrderCommand = new RelayCommand(ob =>
                    {
                        Models.OrderModel order = new Models.OrderModel
                        {
                            Address = Address,
                            Date = Date,
                            OrderedComputers = OrderedComputers,
                            PhoneNumber = PhoneNumber,
                            Sum = Sum
                        };

                        //serviceAdo.CreateOrder(order);
                        try
                        {
                            List<mvvmApp.Dal.Abstract.Item> computers = new List<mvvmApp.Dal.Abstract.Item>();
                            foreach (var el in order.OrderedComputers)
                            {
                                computers.Add(new mvvmApp.Dal.Abstract.Item()
                                {
                                    Company = el.Company,
                                    Id = el.Id,
                                    ImagePath = el.ImagePath,
                                    Price = el.Price,
                                    Title = el.Title
                                });
                            }
                            //serviceAdo.Orders.Create

                            Order orderdata = new Order()
                            {
                                Address = order.Address,
                                Sum = order.Sum,
                                Date = order.Date,
                                PhoneNumber = order.PhoneNumber,
                                OrderedComputers = computers
                            };

                            //orderRepo.Create(orderdata);
                            ///////////////////////for test
                            try
                            {
                                //serviceAdo.Orders.Create(orderdata);
                            }
                            catch (Exception ex)
                            {

                            }
                            
                            try
                            {
                                client.SendData(orderdata);
                                MessageBox.Show("Замовлення оформлено. Сума =  "+orderdata.Sum.ToString());
                            }
                            catch (Exception ex)
                            {

                                
                            }
                            
                        }
                        catch (Exception ex)
                        {

                            
                        }

                    },
                    (ob) => OrderedComputers.Count > 0
                    ));
            }
        }
        
        ServiceModuleAdo serviceAdo;
       // ServiceModule service;

        public OrderViewModel(ObservableCollection<ItemModel> items)
        {
            serviceAdo = new ServiceModuleAdo();
            orderRepo = new OrderRepository<Order>(new ApplicationContext("mvvmApp.Dal.Abstract.Entities.ApplicationContext"));
            //var orderedComputers = orderRepository.GetOrderedItems(serviceAdo.Orders.GetItem(1002).Id).ToList();

            OrderedComputers = new ObservableCollection<ItemModel>();
            orderedComputers = items;

        }


    }
}
