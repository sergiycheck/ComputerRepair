using mvvmapp.Models;
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

                                repo.RepairDetail(item.Id);
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
        public ItemRepositoryADO repo;
        public ComponentViewModel( int compId)
        {
            repo = new ItemRepositoryADO();
            List<Detail> details= repo.GetDetails(compId);

            var mapperConf = new MapperConfiguration(config => config.CreateMap<Detail,DetailModel>().ForMember(dest=>dest.ItemId,opt=>opt.MapFrom(src=>src.Item_Id)));
            var mapper = mapperConf.CreateMapper();
            Components = new ObservableCollection<DetailModel>
                (mapper.Map<List<Detail>, ObservableCollection<DetailModel>>(details));





            //Components = new ObservableCollection<ItemModel>
            //{
            //    new ItemModel { Title="video card", Company="Msi", Price=1600,ImagePath=@"D:\filesFromCDisk\important\mvvmapp\Resources\2.1.jpg" },
            //    new ItemModel {Title="Processor inter core i9", Company="Intel", Price =1000,ImagePath=@"D:\filesFromCDisk\important\mvvmapp\Resources\2.2.png"},
            //    new ItemModel {Title="Mother board", Company="Msi", Price=1200,ImagePath=@"D:\filesFromCDisk\important\mvvmapp\Resources\2.3.png" },
            //    new ItemModel {Title="MSI monitor", Company="Msi", Price=1350,ImagePath=@"D:\filesFromCDisk\important\mvvmapp\Resources\2.4.jpg" },
            //    new ItemModel {Title="key board", Company="Samsund", Price=150,ImagePath=@"D:\filesFromCDisk\important\mvvmapp\Resources\2.5.jpg" }
            //};
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
