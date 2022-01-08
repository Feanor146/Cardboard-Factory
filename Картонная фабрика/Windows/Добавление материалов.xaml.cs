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
namespace Картонная_фабрика.Windows
{    
    public partial class Добавление_материалов : Page,Interface
    {
        public Добавление_материалов()
        {
            InitializeComponent();
        }
        private void Добавление_Click(object sender, RoutedEventArgs e)
        {
            if (ProcessingWindow())
            {
                Classes.Material material = new Classes.Material { NameMaterial = Название.Text, Price = Convert.ToDecimal(Цена.Text), Count = Convert.ToInt32(Количество.Text) };
                Classes.DataBaseWork.AddMaterial(material);
                Название.Text = "";
                Цена.Text = "";
                Количество.Text = "";
            }
        }
        public bool ProcessingWindow()
        {
            if (Название.Text == "" & Цена.Text == "" & Количество.Text == "")
            {
                Classes.Message.SendMessage("Необходимо заполнить все поля!");
                return false;
            }
            try
            {
                Convert.ToString(Цена.Text);
            }
            catch
            {
                Classes.Message.SendMessage("Цена введена некорректно!");
                return false;
            }
            try
            {
                Convert.ToInt16(Количество.Text);
            }
            catch
            {
                Classes.Message.SendMessage("Количество введено некорректно");
                return false;
            }
            return true;
        }
    }
}
