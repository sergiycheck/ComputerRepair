using System.Collections.ObjectModel;

namespace Models
{
    public class UserModel: BaseModel
    {
        public int Id { get; set; }

        private string name;
        private string phoneNumber;
        private string address;
        private string password;
        private ObservableCollection<OrderModel> orders;
        public UserModel() { }
        public UserModel(ObservableCollection<OrderModel> orders)
        {
            this.orders = orders;
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
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
        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged(default);
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
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


    }

    public enum Role
    {
        User,
        Worker
    }
}
