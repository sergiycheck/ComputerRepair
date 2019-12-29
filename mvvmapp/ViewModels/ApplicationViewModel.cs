using AutoMapper;
using mvvmApp.Bll.Infrastructure;
using mvvmApp.Bll.Intecation.Commands;
using mvvmApp.Dal.Abstract;//remove
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using mvvmapp.ServiceReference1;
using mvvmapp.ServiceReference2;

namespace mvvmapp
{
    public class ApplicationViewModel: INotifyPropertyChanged
    {
        
        public ObservableCollection<ItemModel> Computers{ get; set; }
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

                            //Item item = new Item();
                            Computers.Insert(0, computer);
                            SelectedComputer = computer;
                        }catch(Exception ex) 
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
                        

                        //Mapper.Initialize(config => config.CreateMap<ItemModel, Item>());
                        var mapperConf = new MapperConfiguration(config => config.CreateMap<ItemModel, Item>());
                        var mapper = mapperConf.CreateMapper();
                        Item item = mapper.Map<ItemModel, Item>(el);

                        if (ob != null)
                        {

                            try
                            {
                                try
                                {
                                    serviceAdo.Items.Create(item);
                                }
                                catch (Exception ex)
                                {

                                }
                                try
                                {
                                    service.Items.Create(item);
                                }
                                catch (Exception ex)
                                {

                                }

                                client.ItemAdded(item.ToString());
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
                                try
                                {
                                    serviceAdo.Items.Delete(item.Id);
                                }
                                catch (Exception ex)
                                {

                                }
                                try
                                {
                                    service.Items.Delete(item.Id);
                                }
                                catch (Exception ex)
                                {


                                }

                                client.ItemDeleted(item.Id);
                            }
                            catch (Exception ex)
                            {

                                
                            }
                            //service.Items.Delete(item.Id);
                        }
                            
                    },
                    (ob)=>Computers.Count>0
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
                            service.Items.Save();
                        }
                        catch (Exception ex)
                        {

                        }
                        
                    }));
            }
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

                        var mapperConf = new MapperConfiguration(config => config.CreateMap<ItemModel, Item>());
                        var mapper = mapperConf.CreateMapper();
                        Item item = mapper.Map<ItemModel, Item>(el);

                        if (ob != null)
                        {
                            
                            try 
                            {
                                try
                                {
                                    serviceAdo.Items.Update(item);
                                }
                                catch (Exception ex)
                                {

                                   
                                }
                                try
                                {
                                    service.Items.Update(item);
                                }
                                catch (Exception ex )
                                {


                                }

                                client.ItemUpdated(item.Id, item.Title);
                            }catch(Exception ex)
                            {

                            }
                            
                            //service.Items.Update(item);
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




        private ServiceModule service;
        private ServiceModuleAdo serviceAdo;

        ItemServiceClient client;

        ItemDTOServiceClient clientDto;
        public ApplicationViewModel()
        {
            service = new ServiceModule("mvvmApp.Dal.Abstract.Entities.ApplicationContext");
            serviceAdo = new ServiceModuleAdo();

            List<Item> computersIEnum = serviceAdo.Items.GetAllItems().ToList();//service.Items.GetAllItems().ToList();//client.GetAllItems().ToList(); //


            try
            {
                clientDto = new ItemDTOServiceClient();

                List<ItemDTO> itemDTOs = new List<ItemDTO>(clientDto.GetAll());

                var mapperConfig = new MapperConfiguration(config => config.CreateMap<ItemDTO, ItemModel>());
                var map = mapperConfig.CreateMapper();

                Computers = new ObservableCollection<ItemModel>
                    (map.Map<List<ItemDTO>, ObservableCollection<ItemModel>>(itemDTOs));
                
            }
            catch (Exception ex)
            {

            }

            try
            {
                client = new ItemServiceClient();
                if (client != null) 
                {
                    string ItemData = "";
                    foreach (var item in computersIEnum)
                    {
                        ItemData += item.ToString() + "\n";
                    }
                    client.ItemsFromDatabase(ItemData);
                    
                }
                
            }
            catch (Exception ex)
            {

                
            }




            //var mapperConf  = new MapperConfiguration(conf => conf.CreateMap<Item, ItemModel>());
            //var mapper = mapperConf.CreateMapper();

            //Computers = new ObservableCollection<ItemModel>
            //    (mapper.Map<List<Item>, ObservableCollection<ItemModel>>(computersIEnum));
            
            
            


            //serviceAdo = new ServiceModuleAdo();

            //var computersIEnum = serviceAdo.Items.GetAllItems().ToList();

            //var orders = serviceAdo.Orders.GetAllItems();

            //Computers = serviceAdo.Computers;

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
