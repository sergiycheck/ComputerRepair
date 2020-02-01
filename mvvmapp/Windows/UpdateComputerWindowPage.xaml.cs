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
    /// Interaction logic for UpdateComputerWindowPage.xaml
    /// </summary>
    public partial class UpdateComputerWindowPage : Page
    {
        NavigationService nav;
        public UpdateComputerWindowPage()
        {
            InitializeComponent();
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            HomeWindowPage Page = new HomeWindowPage();
            nav.Navigate(Page);
            //Navigation.OpenHomeWindow(this, e);

        }
    }
}
