using mvvmApp.Bll.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmapp.ViewModels
{
    public class ActionsItemViewModel : INotifyPropertyChanged
    {
        protected ServiceModuleAdo serviceAdo;
        protected ServiceModule service;
        protected ItemModel computer;

        protected int id;
        public int Id
        {
            get => id;

            set
            {
                id = value;
                computer.Id = id;
                OnPropertyRaised("Id");
            }
        }

        protected int price;
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                computer.Price = price;
                OnPropertyRaised("Price");
            }
        }

        protected string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                computer.Title = title;
                OnPropertyRaised("Title");
            }
        }
        protected string company;
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
                computer.Company = company;
                OnPropertyRaised("Company");
            }
        }
        protected string image;
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                computer.ImagePath = image;
                OnPropertyRaised("Image");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
