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
using System.Data;
namespace Картонная_фабрика.Windows
{
    public partial class Обзор_материалов : Page
    {
        DataView dataView = Classes.Material.Materials.DefaultView;
        public Обзор_материалов()
        {
            InitializeComponent();
            dataView.Sort = "[Название материала] asc";
            Товары.ItemsSource = dataView;
        }
        private void Материалы_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var grid = (DataGrid)sender;
            if (Key.Delete == e.Key)
            {
                foreach (DataRowView row in grid.SelectedItems)
                {
                    int i = Convert.ToInt16(row["ID"]);                     
                    Classes.DataBaseWork.Delete(i,"Material");
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataView.Sort = "[Название материала] asc";
            Товары.ItemsSource = dataView;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataView.Sort = "[Название материала] desc";
            Товары.ItemsSource = dataView;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dataView.Sort = "Цена(р.) asc";
            Товары.ItemsSource = dataView;            
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dataView.Sort = "Цена(р.) desc";
            Товары.ItemsSource = dataView;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            dataView.Sort = "Количество asc";
            Товары.ItemsSource = dataView;
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            dataView.Sort = "Количество desc";
            Товары.ItemsSource = dataView;
        }
    }
}
