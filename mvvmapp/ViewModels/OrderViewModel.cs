using System;
using System.Linq;
using System.Collections.ObjectModel;
using mvvmApp.Bll.Intecation.Commands;
using System.Windows;
using mvvmApp.Bll;
using mvvmApp.Bll.Mapper;
using Models;

namespace mvvmapp.ViewModels
{
    public class OrderViewModel : OrderModel
    {      
        private ItemModel selectedOrderedComputer;
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
                        OrderModel order = new OrderModel
                        {
                            Address = Address,
                            Date = Date,
                            OrderedComputers = OrderedComputers,
                            PhoneNumber = PhoneNumber,
                            Sum = Sum
                        };

                        
                        try
                        {
                            OrderBll.Create(Mapper.Convert(order));
                            MessageBox.Show("Замовлення оформлено. Сума =  " + order.Sum.ToString());

                        }
                        catch (Exception ex)
                        {

                            
                        }

                    },
                    (ob) => OrderedComputers.Count > 0
                    ));
            }
        }



        OrderBll OrderBll;
        Mapper Mapper;
        public OrderViewModel(ObservableCollection<ItemModel> items)
        {
            OrderedComputers = items;
            try
            {
                Mapper = new Mapper();
                OrderBll = new OrderBll();
            }
            catch (Exception ex)
            {

            }

        }


    }
}
