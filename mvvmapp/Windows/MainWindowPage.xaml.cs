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
    /// Interaction logic for MainWindowPage.xaml
    /// </summary>
    public partial class MainWindowPage : Page
    {
        NavigationService nav;
        public MainWindowPage()
        {
            InitializeComponent();
            
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            LoginWindowPage Page = new LoginWindowPage();
            nav.Navigate(Page);
            //Navigation.OpenLoginWindow(this, e);
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            RegisterWindowPage Page = new RegisterWindowPage();
            nav.Navigate(Page);
            //Navigation.OpenRegisterWindow(this, e);
        }

        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            ViewWindowPage Page = new ViewWindowPage();
            nav.Navigate(Page);
            //Navigation.OpenViewWindow(this, e);
        }
    }
}
