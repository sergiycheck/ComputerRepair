using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private RegisterViewModel viewModel;
        public RegisterWindow()
        {
            InitializeComponent();
            viewModel = new RegisterViewModel();
            this.DataContext = viewModel;

        }

        private void RegisterConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.Register())
            {
                Navigation.OpenHomeWindow(this, e);
            }
            
           
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.OpenMainWindow(this, e);
        }

        private string passwordToCheck;
        [DebuggerStepThrough]
        private void ConfirmedPasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            string confirmedPassword;
            if (this.DataContext != null)
            {
                confirmedPassword = ((PasswordBox) sender).Password;
                if (passwordToCheck != null)
                {
                    if ((confirmedPassword == passwordToCheck))
                    {
                        ((RegisterViewModel)this.DataContext).Password = confirmedPassword;
                    }
                }
                
            }
        }
        [DebuggerStepThrough]
        private void InitialPasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            passwordToCheck = ((PasswordBox) sender).Password;
        }
    }
}
