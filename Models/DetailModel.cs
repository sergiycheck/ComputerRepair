using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models
{
    public class DetailModel : BaseModel
    {
        private string title;
        private string company;
        private int price;
        private string imagePath;

        private bool status;

        public int Id { get; set; }
        public int? ItemId { get; set; }
        public ItemModel Item { get; set; }
        public DetailModel()
        {

        }
        public DetailModel(ItemModel Item) 
        {
            this.Item = Item;
        }
        public bool Status 
        {
            get { return status; }
            set 
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }
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


    }
}
