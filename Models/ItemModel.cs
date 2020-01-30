using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract(IsReference = true)]
    public class ItemModel : BaseModel
    {
        private string title;
        private string company;
        private int price;
        private string imagePath;
        protected List<OrderModel> orders;

        private ObservableCollection<DetailModel> details;
        public ItemModel() 
        {

        }
        public ItemModel(List<OrderModel> Orders) 
        {
            this.Orders = Orders;
        }
        public int Id { get; set; }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }
        public string Company
        {
            get { return company; }
            set
            {
                company = value;
                OnPropertyChanged("Company");
            }
        }
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public virtual List<OrderModel> Orders
        {
            get
            {
                return orders;
            }
            set
            {
                orders = value;
                OnPropertyChanged("Orders");
            }
        }

        public virtual ObservableCollection<DetailModel> Details
        {
            get
            {
                return details;
            }
            set
            {
                details = value;
                OnPropertyChanged("Details");
            }
        }

    }
}
