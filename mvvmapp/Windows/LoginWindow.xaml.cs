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
using mvvmapp.ViewModels;

namespace mvvmapp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginViewModel logModel;

        public LoginWindow()
        {
            InitializeComponent();
            logModel = new LoginViewModel();
            this.DataContext = logModel;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.OpenHomeWindow(this, e);
        }

        private void forgotPaswordLink_Click(object sender, RoutedEventArgs e)
        {
            Navigation.OpenForgotPasswordWindow(this, e);
        }


        private void WorkerLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.OpenHomeWorker(this, e);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.OpenMainWindow(this, e);
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((LoginViewModel) this.DataContext).Password = ((PasswordBox) sender).Password;
            }
        }

        private void LoginUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (logModel.Verify())
            {
                MessageBox.Show("Авторизовано");
                Navigation.OpenHomeWindow(this, e);
            }
            else
            {
                MessageBox.Show("Паролі не правильні");
            }
        }
    }
}
