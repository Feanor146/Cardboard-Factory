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
    public partial class Авторизация : Window, Interface
    {
        public Авторизация()
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
        private void КАвторизация_Click(object sender, RoutedEventArgs e)
        {
            if(ProcessingWindow())
            {
                if (Classes.DataBaseWork.Autorization(Логин.Text, Пароль.Password))
                {
                    Картонная_фабрика картонная_Фабрика = new Картонная_фабрика();
                    картонная_Фабрика.Show();
                    Close();
                }
            }
        }
        private void КРегистрация_Click(object sender, RoutedEventArgs e)
        {
            Регистрация регистрация = new Регистрация();
            регистрация.Show();
            Close();
        }
    }
}
