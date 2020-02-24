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
        protected ObservableCollection<OrderModel> orders;

        private ObservableCollection<DetailModel> details;
        public ItemModel() 
        {

        }
        public ItemModel(ObservableCollection<OrderModel> orders) 
        {
            this.orders = orders;
        }
        public ItemModel(ObservableCollection<OrderModel> orders, ObservableCollection<DetailModel> details)
        {
            this.orders = orders;
            this.details = details;
        }
        public int Id { get; set; }

        public string Title
        {
            get => title; 
            set
            {
                title = value;
                OnPropertyChanged(default);
            }
        }
        public string ImagePath
        {
            get => imagePath; 
            set
            {
                imagePath = value;
                OnPropertyChanged(default);
            }
        }
        public string Company
        {
            get => company; 
            set
            {
                company = value;
                OnPropertyChanged(default); ;
            }
        }
        public int Price
        {
            get => price; 
            set
            {
                price = value;
                OnPropertyChanged(default);
            }
        }
        public virtual ObservableCollection<OrderModel> Orders
        {
            get => orders;
            set
            {
                orders = value;
                OnPropertyChanged(default);
            }
        }

        public virtual ObservableCollection<DetailModel> Details
        {
            get => details;
            set
            {
                details = value;
                OnPropertyChanged(default);
            }
        }

    }
}
