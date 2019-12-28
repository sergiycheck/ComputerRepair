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

namespace mvvmapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {

            
            InitializeComponent();
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.OpenLoginWindow(this, e);
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.OpenRegisterWindow(this, e);
        }

        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.OpenViewWindow(this, e);
        }
    }
}
