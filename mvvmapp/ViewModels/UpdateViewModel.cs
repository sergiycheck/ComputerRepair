﻿using mvvmApp.Bll.Infrastructure;
using mvvmApp.Bll.Intecation.Commands;
using mvvmApp.Dal.Abstract.Entities;
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
    public class UpdateViewModel : ActionsItemViewModel
    {


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
                        try
                        {
                            Item item = new Item()
                            {
                                Company = computer.Company,
                                Id = computer.Id,
                                ImagePath = computer.ImagePath,
                                Price = computer.Price,
                                Title = computer.Title
                            };
                            try
                            {
                                serviceAdo.Items.Update(item);
                            }
                            catch (Exception ex)
                            {

                            }
                            
                            service.Items.Update(item);
                            MessageBox.Show("Відредаговано" + item.ToString());
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    ));
            }
        }

        public UpdateViewModel(ItemModel updatedComputer)
        {
            service = new ServiceModule("mvvmApp.Dal.Abstract.Entities.ApplicationContext"); 
            serviceAdo = new ServiceModuleAdo();
            computer = updatedComputer;

            image = computer.ImagePath;
            company = computer.Company;
            title = computer.Title;
            price = computer.Price;
            id = computer.Id;

        }

    }
}
