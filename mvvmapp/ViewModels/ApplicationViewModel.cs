using AutoMapper;
using mvvmApp.Bll.Intecation.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using mvvmapp.DTOServiceReference;
using System.Data.Entity;
using Models;

namespace mvvmapp
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ItemModel> computers = new ObservableCollection<ItemModel>();
        public ObservableCollection<ItemModel> Computers 
        {
            get
            {
                if(computers.Count == 0)
                {
                    List<ItemDTO> itemDTOs = new List<ItemDTO>(clientDto.GetAllItem());//get all items
                    computers = GetItemModels(itemDTOs);
                    return computers;
                }
                else 
                {
                    return computers;
                }
                
            }
            set 
            {
                computers = value;
            }

        }
        public ObservableCollection<ItemModel> GetItemModels(List<ItemDTO> itemDTOs)
        {
            try
            {
                List<ItemModel> itemModels = new List<ItemModel>();
                //foreach (var el in itemDTOs) 
                //{ }

                var mapperConfig = new MapperConfiguration(config =>
                {
                    //config.CreateMap<ItemDTO, ItemModel>()
                    //.ForMember(d => d.Orders, opt => opt.MapFrom
                    //(src => Mapper.Map<OrderDTO[], List<OrderModel>>(src.Orders))).MaxDepth(3);

                    config.CreateMap<DetailDTO[], ObservableCollection<DetailModel>>().ReverseMap();

                    config.CreateMap<ItemDTO[], List<ItemModel>>().
                    ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Length));
                    config.CreateMap<OrderDTO[], List<OrderModel>>().
                    ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Length));

                    //config.CreateMap<ItemModel,ItemDTO>()
                    //.ForMember(d=>d.Orders,opt=>opt.MapFrom(src=>src.Orders.ToArray()))
                    //.ForMember(dest => dest.ExtensionData, opt => opt.Ignore()).ReverseMap().MaxDepth(3);
                    //config.CreateMap<OrderModel,OrderDTO>()
                    //.ForMember(d=>d.OrderedComputers,opt=>opt.MapFrom(src=>src.OrderedComputers.ToArray()))
                    //.ForMember(dest => dest.ExtensionData, opt => opt.Ignore()).ReverseMap().MaxDepth(3);

                    //config.CreateMap<ItemDTO[], List<ItemModel>>();
                    //config.CreateMap<OrderDTO[], List<OrderModel>>();

                    //config.CreateMap<OrderDTO, OrderModel>().
                    //ForMember(dest => dest.OrderedComputers, opt => opt.MapFrom
                    //(src => Mapper.Map<ItemDTO[], List<ItemModel>>(src.OrderedComputers))).MaxDepth(3);

                    config.AllowNullDestinationValues = true;
                });
                mapperConfig.AssertConfigurationIsValid();

                var map = mapperConfig.CreateMapper();
                //ItemModel itemModel = new ItemModel();
                try
                {
                    itemModels = map.Map<List<ItemDTO>, List<ItemModel>>(itemDTOs);
                }
                catch (Exception ex)
                {


                }
                //itemModels.Add(itemModel);

                return new ObservableCollection<ItemModel>(itemModels);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public ObservableCollection<ItemModel> OrderedComputers { get; set; }


        private RelayCommand addComputerCommand;
        public RelayCommand AddComputerCommand
        {
            get
            {
                if (addComputerCommand != null)
                    return addComputerCommand;
                else
                    return (addComputerCommand = new RelayCommand(ob =>
                    {
                        StackPanel result = ob as StackPanel;
                        try
                        {
                            ItemModel computer = new ItemModel()
                            {
                                Title = result.Children.OfType<TextBox>().FirstOrDefault(n => n.Name == "TitleTxt").Text.ToString(),
                                Company = result.Children.OfType<TextBox>().FirstOrDefault(n => n.Name == "CompanyTxt").Text.ToString(),
                                ImagePath = result.Children.OfType<TextBox>().FirstOrDefault(n => n.Name == "ImageTxt").Text.ToString(),
                                Price = Convert.ToInt32(result.Children.OfType<TextBox>().FirstOrDefault(n => n.Name == "PriceTxt").Text.ToString())
                            };

                            computers.Insert(0, computer);
                            SelectedComputer = computer;
                        } catch (Exception ex)
                        {

                        }

                    }));
            }
        }
        private RelayCommand addComputerToDatabaseCommand;
        public RelayCommand AddComputerToDatabaseCommand
        {
            get
            {
                if (addComputerToDatabaseCommand != null)
                    return addComputerToDatabaseCommand;
                else
                    return (addComputerToDatabaseCommand = new RelayCommand(ob =>
                    {
                        ItemModel el = ob as ItemModel;


                        if (ob != null)
                        {

                            try
                            {
                                clientDto.CreateItem(getItemDTO(el), new DetailDTO());
                            }
                            catch (Exception ex)
                            {
                            }

                        }

                    }));
            }
        }
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
                        ItemModel item = ob as ItemModel;
                        if (ob != null)
                        {
                            Computers.Remove(item);

                            try
                            {
                                clientDto.DeleteItem(getItemDTO(item));

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

        private RelayCommand saveComputerCommand;

        public RelayCommand SaveComputerCommand
        {
            get
            {
                if (saveComputerCommand != null)
                    return saveComputerCommand;
                else
                    return (saveComputerCommand = new RelayCommand(ob =>
                    {
                        try
                        {

                        }
                        catch (Exception ex)
                        {
                        }

                    }));
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
        private RelayCommand updateComputerCommand;
        public RelayCommand UpdateComputerCommand
        {
            get
            {
                if (updateComputerCommand != null)
                    return updateComputerCommand;
                else
                    return (updateComputerCommand = new RelayCommand(ob =>
                    {
                        ItemModel el = ob as ItemModel;

                        if (ob != null)
                        {
                            try
                            {
                                clientDto.UpdateItem(getItemDTO(el));
                            } catch (Exception ex)
                            {

                            }

                        }

                    },
                    (ob) => Computers.Count > 0
                    ));
            }
        }

        private RelayCommand moveToOrderList;
        public RelayCommand MoveToOrderList
        {
            get
            {
                if (moveToOrderList != null)
                    return moveToOrderList;
                else
                    return (moveToOrderList = new RelayCommand(ob =>
                    {
                        ItemModel item = ob as ItemModel;
                        if (ob != null)
                        {
                            OrderedComputers.Add(item);
                        }

                    },
                    (ob) => Computers.Count > 0
                    ));
            }
        }
        private ItemModel selectedComputer;
        public ItemModel SelectedComputer
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


    
        public DTOServiceClient clientDto;
        public ApplicationViewModel()
        {

            try
            {
                
                clientDto = new DTOServiceClient("BasicHttpBinding_IDTOService");  
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
