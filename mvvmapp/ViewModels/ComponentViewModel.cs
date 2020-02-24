
using mvvmApp.Dal.Abstract.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmApp.Dal.Abstract.Entities;

using mvvmApp.Bll.Intecation.Commands;
using System.Windows;
using Models;
using mvvmApp.Bll;
using mvvmApp.Bll.Mapper;

namespace mvvmapp
{
    public class ComponentViewModel : INotifyPropertyChanged
    {

        private RelayCommand repairComputerCommand;
        public RelayCommand RepairComputerCommand
        {
            get
            {
                if (repairComputerCommand != null)
                    return repairComputerCommand;
                else
                    return (repairComputerCommand = new RelayCommand(ob =>
                    {
                        DetailModel item = ob as DetailModel;
                        if (ob != null)
                        {
                            try
                            {
                                detailBll.Repair(item.Id);
                                MessageBox.Show("Деталь комп'ютера номер " + item.ItemId + " успішно  відремонтована");
                            }
                            catch (Exception ex)
                            {


                            }

                        }

                    },
                    (ob) => Components.Count > 0
                    ));
            }
        }

        private ObservableCollection<DetailModel> components;

        public ObservableCollection<DetailModel> Components
        {
            get
            {
                try
                {
                    components = Mapper.ConvertList(detailBll.GetAll(compId));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }

                return components;
            }
            set { components = value; }
        }
        private DetailModel selectedDetail;
        public DetailModel SelectedDetail
        {
            get
            {
                return selectedDetail;
            }
            set
            {
                selectedDetail = value;
                OnPropertyRaised("SelectedDetail");
            }
        }

        private DetailBll detailBll;
        private Mapper Mapper;
        private int compId;
        public ComponentViewModel( int compId)
        {
            detailBll = new DetailBll();
            Mapper = new Mapper();
            this.compId = compId;


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
