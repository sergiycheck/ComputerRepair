using System;
using System.Linq;
using System.Collections.ObjectModel;

using mvvmApp.Bll.Intecation.Commands;
using System.Windows;
using AutoMapper;
using mvvmapp.DTOServiceReference;
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
                            var mapperConf = new MapperConfiguration(config =>
                            {
                                config.CreateMap<ItemModel, ItemDTO>()
                                .ForMember(dest=>dest.ExtensionData,opt=>opt.Ignore());//took >3 hours to solve
                                config.CreateMap<OrderModel, OrderDTO>()
                                .ForMember(dest=>dest.ExtensionData,opt=>opt.Ignore());
                                config.CreateMap<DetailModel, DetailDTO>()
                                .ForMember(dest => dest.ExtensionData, opt => opt.Ignore());
                                
                            });
                            
                            mapperConf.AssertConfigurationIsValid();
                            var mapper = mapperConf.CreateMapper();
                            var orderDTO = mapper.Map<OrderModel, OrderDTO> (order);
                            orderClientDTO.CreateOrder(orderDTO);
                            MessageBox.Show("Замовлення оформлено. Сума =  "+orderDTO.Sum.ToString()); 
                        }
                        catch (Exception ex)
                        {

                            
                        }

                    },
                    (ob) => OrderedComputers.Count > 0
                    ));
            }
        }



        DTOServiceClient orderClientDTO;
        public OrderViewModel(ObservableCollection<ItemModel> items)
        {



            orderClientDTO = new DTOServiceClient("BasicHttpBinding_IDTOService");
            
            //OrderedComputers = new ObservableCollection<ItemModel>();
            //orderedComputers = items;

        }


    }
}
