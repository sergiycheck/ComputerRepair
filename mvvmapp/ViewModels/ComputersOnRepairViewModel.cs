using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;

using mvvmApp.Bll.Intecation.Commands;
using mvvmApp.Dal.Abstract;
using mvvmApp.Dal.Abstract.Entities;
using mvvmApp.Dal.Abstract.Repositories;
using mvvmapp.DTOServiceReference;
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
        private ItemDTO getItemDTO(ItemModel el)
        {
            var mapperConfDTO = new MapperConfiguration(config =>
            {
                config.CreateMap<ItemModel, ItemDTO>();
                config.CreateMap<OrderModel, OrderDTO>();
                config.CreateMap<DetailModel, DetailDTO>();
            });
            var mapperDTO = mapperConfDTO.CreateMapper();
            ItemDTO itemDTO = mapperDTO.Map<ItemModel, ItemDTO>(el);
            return itemDTO;
        }
        private ItemModel GetItemModels(ItemDTO itemDTOs)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ItemDTO, ItemModel>();
                config.CreateMap<OrderDTO, OrderModel>();
                config.CreateMap<DetailDTO, DetailModel>();
            });
            var map = mapperConfig.CreateMapper();
            return map.Map<ItemDTO,ItemModel>(itemDTOs);
        }
        private ItemOnRepair GetItemOnRepair(ItemModel itemModel) 
        {
    //        var mapperConf = new MapperConfiguration(
    //config => config.CreateMap<ItemModel, ItemOnRepair>()
    //    .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Orders.First().Id)));
    //        var mapper = mapperConf.CreateMapper();
    //        mapper.Map<ItemModel, ItemOnRepair>(itemModel);
            return null; 

        }
        DTOServiceClient clientDto;
        public ObservableCollection<ItemOnRepair> Computers { get; set; }
        public ComputersOnRepairViewModel()
        {
            clientDto = new DTOServiceClient("BasicHttpBinding_IDTOService");
            Computers = new ObservableCollection<ItemOnRepair>();
            
            try
            {
                List<OrderDTO> orderDTOs = clientDto.GetOrderedComputers().ToList();
                foreach(var o in orderDTOs) 
                {
                    foreach(var c in o.OrderedComputers) 
                    {
                        Computers.Add(GetItemOnRepair(GetItemModels(c)));
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
