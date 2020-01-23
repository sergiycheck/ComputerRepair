using AutoMapper;

using mvvmApp.Bll.Intecation.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmApp.Dal.Abstract;

using System.Windows;

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

                        var mapperConf = new MapperConfiguration(config => config.CreateMap<ItemModel, Item>());
                        var mapper = mapperConf.CreateMapper();
                        Item item = mapper.Map<ItemModel, Item>(computer);

                        //serviceAdo.Items.Create(item);
                        
                        try 
                        {
                            ;
                            
                        }
                        catch(Exception ex) 
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        

                    }
                    ));
            }
        }

        public AddViewModel()
        {
            
            computer = new ItemModel();
        }


    }
}
