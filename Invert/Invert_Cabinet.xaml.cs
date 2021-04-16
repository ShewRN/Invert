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
using MaterialDesignThemes.Wpf;
namespace Invert
{
    /// <summary>
    /// Логика взаимодействия для Invert_Cabinet.xaml
    /// </summary>
    public partial class Invert_Cabinet : Window
    {
        Database1Entities db;
        public Invert_Cabinet()
        {
            InitializeComponent();
            db = new Database1Entities();
        }
        //ВКЛАДКА КАБИНЕТОВ
        private void Cb_Cabinet_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cb_Cabinet_1.SelectedIndex == 0)
            {
                //показать полный список
                //скорее всего, нужно тупо сложить кол-во оборудования во всех кабинетах
            }
            else if (Cb_Cabinet_1.SelectedIndex == 1)
            {
                //показать список оборудования кабинета 1
            }
            else if (Cb_Cabinet_1.SelectedIndex == 2)
            {
                //показать список оборудования кабинета 2
            }
            else if (Cb_Cabinet_1.SelectedIndex == 3)
            {
                //показать список оборудования кабинета 3
            }
        }
        private void Monitor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Table_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Chair_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Computer_Case_Click(object sender, RoutedEventArgs e)
        {

        }
        //ВКЛАДКА РЕДАКТИРОВАНИЯ ТАБЛИЦЫ
        private void Insert(object sender, RoutedEventArgs e)
        {
            
        }

        private void Delete(object sender, RoutedEventArgs e)
        {

        }

        private void Update(object sender, RoutedEventArgs e)
        {

        }
        //ЗАГРУЗКА ДАННЫХ В ТАБЛИЦАХ
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new Database1Entities();
            //вывод таблицы
        }

    }
}
