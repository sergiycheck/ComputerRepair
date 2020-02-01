using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
        public OrderModel(ObservableCollection<ItemModel> OrderedComputers)
        {
            this.OrderedComputers = OrderedComputers;
        }
        public decimal Sum
        {
            get
            {
                return sum;
            }
            set
            {
                foreach(var el in orderedComputers)
                {
                    sum += el.Price;
                }
                OnPropertyChanged("Sum");
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = DateTime.Now;
                OnPropertyChanged("Date");
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        public virtual ObservableCollection<ItemModel> OrderedComputers
        {
            get
            {
                return orderedComputers;
            }
            set
            {
                orderedComputers = value;
                OnPropertyChanged("OrderedComputers");
            }
        }



    }
}
