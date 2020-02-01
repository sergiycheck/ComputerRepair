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
    /// Interaction logic for ComponentsWindowPage.xaml
    /// </summary>
    public partial class ComponentsWindowPage : Page
    {
        NavigationService nav;
        public ComponentsWindowPage(int compId)
        {
            this.DataContext = new ComponentViewModel(compId);
            InitializeComponent();
        }
        private void BackToHomeWorkerBtn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            HomeWorkerPage Page = new HomeWorkerPage();
            nav.Navigate(Page);
            //Navigation.OpenHomeWorker(this, e);
        }
    }
}
