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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mvvmapp.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindowPage.xaml
    /// </summary>
    public partial class LoginWindowPage : Page
    {
        private LoginViewModel logModel;
        NavigationService nav;
        public LoginWindowPage()
        {
            
            logModel = new LoginViewModel();
            this.DataContext = logModel;
            InitializeComponent();
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            HomeWindowPage Page = new HomeWindowPage();
            nav.Navigate(Page);
            //Navigation.OpenHomeWindow(this, e);
        }

        private void forgotPaswordLink_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            ForgotPasswordWindowPage Page = new ForgotPasswordWindowPage();
            nav.Navigate(Page);
            //Navigation.OpenForgotPasswordWindow(this, e);
        }


        private void WorkerLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            HomeWorkerPage Page = new HomeWorkerPage();
            nav.Navigate(Page);
            //Navigation.OpenHomeWorker(this, e);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            nav = NavigationService.GetNavigationService(this);
            MainWindowPage Page = new MainWindowPage();
            nav.Navigate(Page);
            //Navigation.OpenMainWindow(this, e);
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((LoginViewModel)this.DataContext).Password = ((PasswordBox)sender).Password;
            }
        }

        private void LoginUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (logModel.Verify())
            {
                MessageBox.Show("Авторизовано");
                nav = NavigationService.GetNavigationService(this);
                HomeWindowPage Page = new HomeWindowPage();
                nav.Navigate(Page);
                //Navigation.OpenHomeWindow(this, e);
            }
            else
            {
                MessageBox.Show("Паролі не правильні");
            }
        }
    }
}
