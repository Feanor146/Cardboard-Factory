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
    public partial class Регистрация : Window,Interface
    {
        public Регистрация()
        {
            InitializeComponent();
        }
        public bool ProcessingWindow()
        {
            if (Логин.Text == "" & Пароль.Password == "")
            {
                Classes.Message.SendMessage("Необходимо ввести логин и пароль");
                return false;
            }
            else if (Логин.Text == "")
            {
                Classes.Message.SendMessage("Необходимо ввести логин");
                return false;
            }
            else if (Пароль.Password == "")
            {
                Classes.Message.SendMessage("Необходимо ввести Пароль");
                return false;
            }
            return true;
        }
        private void КРегистрация_Click(object sender, RoutedEventArgs e)
        {
            if (ProcessingWindow())
            {
                Classes.User user = new Classes.User{ Login = Логин.Text,Password = Пароль.Password };                
                Classes.DataBaseWork.RegistrationUser(user);
                Авторизация авторизация = new Авторизация();
                авторизация.Show();
                Close();
            }            
        }
        private void КАвторизация_Click(object sender, RoutedEventArgs e)
        {
            Авторизация авторизация = new Авторизация();
            авторизация.Show();
            Close();
        }
    }
}
