using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace mvvmapp.Models
{
    public class UserModel:INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string name;
        private string phoneNumber;
        private string address;
        private string password;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
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
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public enum Role
    {
        User,
        Worker
    }
}
