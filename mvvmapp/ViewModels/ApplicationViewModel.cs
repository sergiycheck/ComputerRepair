
using mvvmApp.Bll.Intecation.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using mvvmApp.Bll;
using System.Data.Entity;
using Models;
using DTOs;
using mvvmApp.Bll.Mapper;

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
                    //get all items
                    try
                    {
                        computers = Mapper.ConvertList(ItemBll.GetAll());
                    }
                    catch (Exception ex)
                    {

                    }
                    
                    
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
                        ItemModel item = ob as ItemModel;


                        if (ob != null)
                        {

                            try
                            {
                                //creating
                                ItemBll.Create(Mapper.Convert(item));
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
                                //deleting
                                ItemBll.Delete(Mapper.Convert(item));

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
                        ItemModel item = ob as ItemModel;

                        if (ob != null)
                        {
                            try
                            {
                                //updating
                                ItemBll.Update(Mapper.Convert(item));

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



        ItemBll ItemBll;
        Mapper Mapper;
        public ApplicationViewModel()
        {

            try
            {
                Mapper = new Mapper();
                ItemBll = new ItemBll();
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
