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
    /// Interaction logic for ViewWindowPage.xaml
    /// </summary>
    public partial class ViewWindowPage : Page
    {
        NavigationService nav;
        public ViewWindowPage()
        {
            InitializeComponent();
        }
        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            MainWindowPage Page = new MainWindowPage();
            nav.Navigate(Page);
            //Navigation.OpenMainWindow(this, e);
        }
    }
}
