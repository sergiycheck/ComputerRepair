using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using mvvmapp.Models;
using mvvmApp.Bll.Intecation.Commands;
using mvvmApp.Dal.Abstract;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract.Repositories;

namespace mvvmapp
{
    public class ComputersOnRepairViewModel : INotifyPropertyChanged
    {



        private RelayCommand deleteComputerCommand;
        public RelayCommand DeleteComputerCommand
        {
            get
            {
                if (deleteComputerCommand != null)
                    return deleteComputerCommand;
                else
                    return (deleteComputerCommand = new RelayCommand(ob =>
                    {
                        ItemOnRepair item = ob as ItemOnRepair;
                        if (ob != null)
                        {
                            Computers.Remove(item);

                            try
                            {

                                repo.RepairComputer(item.Id, item.OrderId);
                                MessageBox.Show("Замовлення номер " + item.OrderId + " успішно виконано. Компютер відремонтований");
                            }
                            catch (Exception ex)
                            {


                            }
                            
                        }

                    },
                    (ob) => Computers.Count > 0
                    ));
            }
        }



        private ItemOnRepair selectedComputer;
        public ItemOnRepair SelectedComputer
        {
            get
            {
                return selectedComputer;
            }
            set
            {
                selectedComputer = value;
                OnPropertyRaised("SelectedComputer");
            }
        }


        public ItemRepositoryADO repo;
        public OrderRepositoryADO orderRepo;
        public ObservableCollection<ItemOnRepair> Computers { get; set; }
        public ComputersOnRepairViewModel()
        {
            repo = new ItemRepositoryADO();
            orderRepo = new OrderRepositoryADO();


            List<Item> items = repo.GetOrderedComputers();

            List<ItemAndOrderId> itemAndOrder = repo.GetOrderedComputersAndOrderId();
            Computers = new ObservableCollection<ItemOnRepair>();
            foreach(var el in itemAndOrder) 
            {
                Computers.Add(new ItemOnRepair
                {
                    Company = el.item.Company,
                    Id = el.item.Id,
                    ImagePath = el.item.ImagePath,
                    Price = el.item.Price,
                    Title = el.item.Title,
                    OrderId = el.OrderId
                });
            }


            

            //Computers = new ObservableCollection<ItemModel>
            //{
            //    new ItemModel { Title="Macbook", Company="Apple", Price=56000,ImagePath=@"D:\filesFromCDisk\important\mvvmapp\Resources\1.jpg" },
            //    new ItemModel {Title="Lenovo 330ich", Company="Lenovo", Price =60000,ImagePath=@"D:\filesFromCDisk\important\mvvmapp\Resources\2.jpg"},
            //};
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
