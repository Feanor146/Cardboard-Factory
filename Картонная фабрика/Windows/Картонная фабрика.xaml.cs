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
namespace Картонная_фабрика.Windows
{    
    public partial class Картонная_фабрика : Window
    {        
        public Картонная_фабрика()
        {
            InitializeComponent();
        }
        private void КРегистрация_Click(object sender, RoutedEventArgs e)
        {
            Регистрация регистрация = new Регистрация();
            регистрация.Show();
            Close();
        }
        private void КАвторизация_Click(object sender, RoutedEventArgs e)
        {
            Авторизация авторизация = new Авторизация();
            авторизация.Show();
            Close();
        }        
        private void Click(object sender, RoutedEventArgs e)
        {
            if(Convert.ToString(((MenuItem)sender).Header) == "Материалы")
            {
                Frame.Navigate(new Uri(@"Windows\Обзор материалов.xaml", UriKind.RelativeOrAbsolute));
            }
            else if (Convert.ToString(((MenuItem)sender).Header) == "Товары")
            {                
                Frame.Navigate(new Uri(@"Windows\Обзор товаров.xaml", UriKind.RelativeOrAbsolute));
            }
        }
        private void Click1(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(((MenuItem)sender).Header) == "Материалы")
            {
                Frame.Navigate(new Uri(@"Windows\Добавление материалов.xaml", UriKind.RelativeOrAbsolute));
            }
            else if (Convert.ToString(((MenuItem)sender).Header) == "Товары")
            {
                Frame.Navigate(new Uri(@"Windows\Добавление товара.xaml", UriKind.RelativeOrAbsolute));
            }
        }
    }
}
