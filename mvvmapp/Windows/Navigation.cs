using Models;
using mvvmapp.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace mvvmapp
{
    public static class Navigation
    {
        private static void createAndShow(object sender,Window window)
        {
            var obj = sender as Window;
            obj.Close();
            window.Show();
        }
        public static void OpenMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            createAndShow(sender, window);
        }
        public static void OpenForgotPasswordWindow(object sender, RoutedEventArgs e)
        {
            ForgotPasswordWindow window = new ForgotPasswordWindow();
            createAndShow(sender, window);
        }
        public static void OpenHomeWindow(object sender, RoutedEventArgs e)
        {
            HomeWindow window = new HomeWindow();
            createAndShow(sender, window);
        }
        public static void OpenLoginWindow(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            createAndShow(sender, window);

        }
        public static void OpenRegisterWindow(object sender, RoutedEventArgs e)
        {
            RegisterWindow window = new RegisterWindow();
            createAndShow(sender, window);
        }
        public static void OpenViewWindow(object sender, RoutedEventArgs e)
        {
            ViewWindow window = new ViewWindow();
            createAndShow(sender, window);
        }
        public static void OpenHomeWorker(object sender, RoutedEventArgs e)
        {
            HomeWorker window = new HomeWorker();
            createAndShow(sender, window);
        }
        public static void OpenComponentsWindow(object sender, RoutedEventArgs e,int compId)
        {
            ComponentsWindow window = new ComponentsWindow(compId);
            createAndShow(sender, window);
        }
        public static void OpenOrderWindow(object sender, RoutedEventArgs e, ObservableCollection<ItemModel> items)
        {
            OrderWindow window = new OrderWindow(items);
            createAndShow(sender, window);
        }
        public static void OpenAddComputerWindow(object sender, RoutedEventArgs e)
        {
            AddComputerWindow window = new AddComputerWindow();
            createAndShow(sender, window);
        }
        public static void OpenUpdateComputerWindow(object sender, RoutedEventArgs e, ItemModel updatedComputer)
        {
            UpdateComputerWindow window = new UpdateComputerWindow(updatedComputer);
            createAndShow(sender, window);
        }
    }
}
