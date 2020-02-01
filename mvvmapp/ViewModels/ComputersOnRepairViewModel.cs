using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using mvvmApp.Bll.Intecation.Commands;
using Models;
using mvvmApp.Bll;
using mvvmApp.Bll.Mapper;
using Models;


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
                                OrderBll.Delete(Mapper.Convert(item.Orders.First()));


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


        
        public ObservableCollection<ItemOnRepair> Computers { get; set; }
        OrderBll OrderBll;
        Mapper Mapper;
        public ComputersOnRepairViewModel()
        {
            OrderBll = new OrderBll();
            Mapper = new Mapper();
            Computers = new ObservableCollection<ItemOnRepair>();
            
            try
            {
                //get ordered computers
                var orders = Mapper.ConvertList(OrderBll.GetOrderWithComputers());
                foreach(var order in orders) 
                {
                    foreach(var comp in order.OrderedComputers) 
                    {
                        
                        ItemOnRepair itemOnRepair = new ItemOnRepair()
                        {
                            OrderId = comp.Orders.First().Id,
                            Company = comp.Company,
                            Details = comp.Details,
                            Id = comp.Id,
                            ImagePath = comp.ImagePath,
                            Orders = comp.Orders,
                            Price = comp.Price,
                            Title = comp.Title
                        };
                        Computers.Add(itemOnRepair);
                    }
                }
            }
            catch (Exception ex)
            {

                
            }

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
