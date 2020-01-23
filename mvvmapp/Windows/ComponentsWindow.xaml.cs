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
    /// Interaction logic for ComponentsWindow.xaml
    /// </summary>
    public partial class ComponentsWindow : Window
    {
        public ComponentsWindow(int compId)
        {
            this.DataContext = new ComponentViewModel(compId);
            InitializeComponent();
        }

        private void BackToHomeWorkerBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.OpenHomeWorker(this, e);
        }
    }
}
