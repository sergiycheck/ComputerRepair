using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace mvvmapp
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public ObservableCollection<ItemModel> OrderedComputers { get; set; }

        public HomeWindow()
        {
            this.DataContext = new ApplicationViewModel();
            InitializeComponent();
            OrderedComputers = new ObservableCollection<ItemModel>();
        }

        private void SignOutBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.OpenLoginWindow(this, e);
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.OpenOrderWindow(this, e, OrderedComputers);
        }

        private void MoveToOrderList_Click(object sender, RoutedEventArgs e)
        {            
            OrderedComputers.Add(GetItem());
        }

        private void AddInNewWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.OpenAddComputerWindow(this, e);
        }
        private ItemModel GetItem()
        {
            return new ItemModel()
            {
                Title = TitleTxt.Text.ToString(),
                Company = CompanyTxt.Text.ToString(),
                Id = Convert.ToInt32(IdTxt.Text.ToString()),
                ImagePath = ImageTxt.Text.ToString(),
                Price = Int32.Parse(PriceTxt.Text.ToString())
            };
        }
        private void UpdateInNewWindow_Click(object sender, RoutedEventArgs e)
        {
            Navigation.OpenUpdateComputerWindow(this, e, GetItem());
        }

    }
}
