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
using System.Windows.Shapes;

namespace mvvmapp
{
    /// <summary>
    /// Interaction logic for HomeWorker.xaml
    /// </summary>
    public partial class HomeWorker : Window
    {
        public HomeWorker()
        {
            this.DataContext = new ComputersOnRepairViewModel();
            InitializeComponent();
        }

        private void SignOutBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.OpenLoginWindow(this, e);
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
            
            Navigation.OpenComponentsWindow(this, e,compId);
        }
    }
}
