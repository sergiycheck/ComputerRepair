using System;
using System.Collections.Generic;
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
    /// Interaction logic for HomeWorkerPage.xaml
    /// </summary>
    public partial class HomeWorkerPage : Page
    {
        NavigationService nav;
        public HomeWorkerPage()
        {
            this.DataContext = new ComputersOnRepairViewModel();
            InitializeComponent();
        }
        private void SignOutBtn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            LoginWindowPage Page = new LoginWindowPage();
            nav.Navigate(Page);
            //Navigation.OpenLoginWindow(this, e);
        }


        private void ComponentsBtn_Click(object sender, RoutedEventArgs e)
        {
            int compId = 0;
            try
            {
                compId = Convert.ToInt32(IdTxt.Text);
            }
            catch (Exception ex)
            {

            }
            nav = NavigationService.GetNavigationService(this);
            ComponentsWindowPage Page = new ComponentsWindowPage(compId);
            nav.Navigate(Page);
            //Navigation.OpenComponentsWindow(this, e, compId);
        }
    }
}
