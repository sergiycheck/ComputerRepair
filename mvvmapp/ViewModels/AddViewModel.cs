using AutoMapper;
using mvvmApp.Bll.Infrastructure;
using mvvmApp.Bll.Intecation.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmApp.Dal.Abstract;
using mvvmApp.Dal.Abstract.Client;
using System.Windows;

namespace mvvmapp.ViewModels
{
    public class AddViewModel : ActionsItemViewModel
    {
        ClientTcpAction ClientTcpAct { get; set; }

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
                        ClientTcpAct = new ClientTcpAction();
                        try 
                        {
                            ClientTcpAct.SendData(item);
                            
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
            serviceAdo = new ServiceModuleAdo();
            computer = new ItemModel();
        }


    }
}
