using mvvmApp.Bll.Mapper;
using mvvmApp.Bll.Intecation.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using mvvmApp.Bll;
using System.Windows;
using Models;

namespace mvvmapp.ViewModels
{
    public class AddViewModel : ActionsItemViewModel
    {
        

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
                      
                        try 
                        {
                            ItemBll.Create(Mapper.Convert(computer));

                        }
                        catch(Exception ex) 
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        

                    }
                    ));
            }
        }

        ItemBll ItemBll;
        Mapper Mapper;
        public AddViewModel()
        {
            try
            {
                Mapper = new Mapper();
                ItemBll = new ItemBll();
            }
            catch (Exception ex)
            {

                throw;
            }


            computer = new ItemModel();
        }


    }
}
