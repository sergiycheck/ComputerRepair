using Models;
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
    /// Interaction logic for HomeWindowPage.xaml
    /// </summary>
    public partial class HomeWindowPage : Page
    {
        public ObservableCollection<ItemModel> OrderedComputers { get; set; }
        NavigationService nav;
        public HomeWindowPage()
        {
            this.DataContext = new ApplicationViewModel();
            OrderedComputers = new ObservableCollection<ItemModel>();
            InitializeComponent();
        }
        private void SignOutBtn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            LoginWindowPage Page = new LoginWindowPage();
            nav.Navigate(Page);
            //Navigation.OpenLoginWindow(this, e);
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            OrderWindowPage Page = new OrderWindowPage(OrderedComputers);
            nav.Navigate(Page);
            //Navigation.OpenOrderWindow(this, e, OrderedComputers);
        }

        private void MoveToOrderList_Click(object sender, RoutedEventArgs e)
        {
            OrderedComputers.Add(GetItem());
        }

        private void AddInNewWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            AddComputerWindowPage Page = new AddComputerWindowPage();
            nav.Navigate(Page);
            //Navigation.OpenAddComputerWindow(this, e);
        }
        private ItemModel GetItem()
        {
            try
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
            catch (Exception ex)
            {

            }
            return null;
        }
        private void UpdateInNewWindow_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            UpdateComputerWindowPage Page = new UpdateComputerWindowPage();
            nav.Navigate(Page);
            //Navigation.OpenUpdateComputerWindow(this, e, GetItem());
        }
    }
}
