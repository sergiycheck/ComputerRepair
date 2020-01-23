using AutoMapper;
using mvvmApp.Bll.Intecation.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using mvvmapp.Models;
using mvvmapp.DTOServiceReference;
using System.Data.Entity;

namespace mvvmapp
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<ItemModel> Computers { get; set; }
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

                            Computers.Insert(0, computer);
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

        public ObservableCollection<ItemModel> GetItemModels(List<ItemDTO> itemDTOs)
        {
            try
            {
                ObservableCollection<ItemModel> itemModels = new ObservableCollection<ItemModel>();
                foreach (var el in itemDTOs) 
                {
                    var mapperConfig = new MapperConfiguration(config =>
                    {
                        config.CreateMap<List<OrderDTO>, ObservableCollection<OrderModel>>().PreserveReferences();
                        config.CreateMap<List<DetailDTO>, ObservableCollection<DetailModel>>();
                        config.CreateMap<ItemDTO, ItemModel>();
                        config.AllowNullDestinationValues = true;
                    });
                    mapperConfig.AssertConfigurationIsValid();

                    var map = mapperConfig.CreateMapper();
                    var dest = map.Map<ItemDTO, ItemModel>(el);
                    itemModels.Add(dest);
                }


                if (itemModels.Count != 0)
                {
                    return itemModels;
                }
                else
                {
                    itemModels = ManuallyMap(itemDTOs, itemModels);
                    return itemModels;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        private ObservableCollection<ItemModel> ManuallyMap(List<ItemDTO> itemDTOs, ObservableCollection<ItemModel> itemModels)
        {
            foreach (var item in itemDTOs)
            {
                ItemModel itemModel = new ItemModel();
                ObservableCollection<DetailModel> detailModels = new ObservableCollection<DetailModel>();
                ObservableCollection<OrderModel> orderModels = new ObservableCollection<OrderModel>();

                itemModel.Company = item.Company;
                itemModel.Id = item.Id;
                itemModel.ImagePath = item.ImagePath;
                itemModel.Price = item.Price;
                itemModel.Title = item.Title;


                foreach (var detail in item.Details)
                {
                    detailModels.Add
                        (
                            new DetailModel()
                            {
                                Company = detail.Company,
                                Id = detail.Id,
                                ImagePath = detail.ImagePath,
                                Price = detail.Price,
                                Status = detail.Status,
                                Title = detail.Title,
                                Item = itemModel,
                                ItemId = itemModel.Id
                            }
                        );
                }

                itemModel.Details = detailModels;

                foreach (var order in item.Orders)
                {
                    orderModels.Add
                    (
                        new OrderModel()
                        {
                            Address = order.Address,
                            Date = order.Date,
                            Id = order.Id,
                            PhoneNumber = order.PhoneNumber,
                            Sum = order.Sum,
                            OrderedComputers = itemModels//bag is here because itemModels not fully set 
                        }
                    );
                }
                itemModel.Orders = orderModels;
                itemModels.Add(itemModel);
            }
            return itemModels;
        }


        public DTOServiceClient clientDto;
        public ApplicationViewModel()
        {

            try
            {
                Computers = new ObservableCollection<ItemModel>();
                clientDto = new DTOServiceClient("BasicHttpBinding_IDTOService");

                List<ItemDTO> itemDTOs = new List<ItemDTO>(clientDto.GetAllItem());//get all items

                Computers = GetItemModels(itemDTOs);
                
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
