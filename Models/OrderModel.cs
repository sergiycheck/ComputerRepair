using System;
using System.Collections.ObjectModel;

namespace Models
{

    public class OrderModel : BaseModel
    {

        public int Id { get; set; }

        private decimal sum;
        private string phoneNumber;
        private DateTime date;
        private string address;
        private ObservableCollection<ItemModel> orderedComputers;
        public OrderModel()
        {

        }
        public OrderModel(ObservableCollection<ItemModel> orderedComputers)
        {
            this.orderedComputers = orderedComputers;
        }
        public decimal Sum
        {
            get => sum;
            set
            {

                foreach (var el in orderedComputers)
                {
                    if(el!=null)
                        sum += el.Price;
                }
                OnPropertyChanged(default);


            }
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged(default);
            }
        }

        public DateTime Date
        {
            get => date;
            set
            {
                date = DateTime.Now;
                OnPropertyChanged(default);
            }
        }

        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged(default);
            }
        }

        public virtual ObservableCollection<ItemModel> OrderedComputers
        {
            get => orderedComputers;
            set
            {
                orderedComputers = value;
                OnPropertyChanged(default);
            }
        }



    }
}
