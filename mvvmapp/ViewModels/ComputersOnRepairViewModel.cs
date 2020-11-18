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
                                
                                OrderBll.DeleteItemFromOrder(item.Id, item.OrderId);


                                MessageBox.Show("Замовлення номер " + item.OrderId + " успішно виконано. Комп`ютер відремонтований");
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
                var orderedItems = Mapper.ConvertList(OrderBll.GetOrderWithComputers());

                foreach (var ord in orderedItems)
                {
                    foreach(var item in ord.OrderedComputers) 
                    {
                        try
                        {
                            ItemOnRepair itemOnRepair = new ItemOnRepair()
                            {
                                OrderId = ord.Id,
                                Company = item.Company,
                                Details = item.Details,
                                Id = item.Id,
                                ImagePath = item.ImagePath,
                                Orders = item.Orders,
                                Price = item.Price,
                                Title = item.Title
                            };
                            Computers.Add(itemOnRepair);
                        }
                        catch (Exception ex)
                        {

                        }
                        
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
