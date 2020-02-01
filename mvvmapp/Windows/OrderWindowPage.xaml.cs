using Models;
using mvvmapp.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mvvmapp.Windows
{
    /// <summary>
    /// Interaction logic for OrderWindowPage.xaml
    /// </summary>
    public partial class OrderWindowPage : Page
    {
        NavigationService nav;
        public OrderWindowPage(ObservableCollection<ItemModel> items)
        {
            this.DataContext = new OrderViewModel(items);
            InitializeComponent();
            
        }
        private void BacktBtn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            MainWindowPage Page = new MainWindowPage();
            nav.Navigate(Page);
            //Navigation.OpenHomeWindow(this, e);
        }
    }
}
