using mvvmapp.ViewModels;
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

namespace mvvmapp.Windows
{
    /// <summary>
    /// Interaction logic for AddComputerWindow.xaml
    /// </summary>
    public partial class AddComputerWindow : Window
    {
        public AddComputerWindow()
        {
            this.DataContext = new AddViewModel();
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.OpenHomeWindow(this, e);

        }
    }
}
