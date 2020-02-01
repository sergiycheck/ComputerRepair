
using mvvmApp.Dal.Abstract.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmApp.Dal.Abstract.Entities;
using AutoMapper;
using mvvmApp.Bll.Intecation.Commands;
using System.Windows;
using Models;

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

        public ObservableCollection<DetailModel> Components { get; set; }
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
       
        public ComponentViewModel( int compId)
        {

            List<Detail> details = null;// repo.GetDetails(compId);

            var mapperConf = new MapperConfiguration(
                config => config.CreateMap<Detail,DetailModel>()
                    .ForMember(dest=>dest.ItemId,opt=>opt.MapFrom(src=>src.ItemId)));
            var mapper = mapperConf.CreateMapper();
            Components = new ObservableCollection<DetailModel>
                (mapper.Map<List<Detail>, ObservableCollection<DetailModel>>(details));

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
