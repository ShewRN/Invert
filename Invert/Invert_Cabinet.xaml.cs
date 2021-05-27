using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public gr691_invert db;
        public Invert_Cabinet()
        {
            InitializeComponent();
            db = new gr691_invert();
            List<Equipment> us = db.Database.SqlQuery<Equipment>("Select*from Equipment Where indef = 'MN'").ToList();
            //Monitor_Count.Content = Convert.ToString(us.Count);
            us = db.Database.SqlQuery<Equipment>("Select*from Equipment Where indef = 'CR'").ToList();

            us = db.Database.SqlQuery<Equipment>("Select*from Equipment Where indef = 'DK'").ToList();
            Table_Count.Text = Convert.ToString(us.Count);
            us = db.Database.SqlQuery<Equipment>("Select*from Equipment Where indef = 'PC'").ToList();
            List<Equipment> ps = db.Equipment.Where(db => db.indef == "CR").ToList();
            Chair_Count.Text = Convert.ToString(ps.Count);
            Computer_Case_Count.Text = Convert.ToString(us.Count);

            Table_Cabinet.ItemsSource = db.Equipment.ToList();
        }

        //ВКЛАДКА КАБИНЕТОВ
        public static string selectedCabinet { get; set; }
        public void Cb_Cabinet_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            db = new gr691_invert();

            if (Cb_Cabinet_1.SelectedIndex == 0)
            {
                Monitor_Count.Text = db.Equipment.Where(w => w.indef == "MN").Count().ToString();
                Chair_Count.Text = db.Equipment.Where(db => db.indef == "CR").Count().ToString();
                Table_Count.Text = db.Equipment.Where(db => db.indef == "DK").Count().ToString();
                Computer_Case_Count.Text = db.Equipment.Where(db => db.indef == "PC").Count().ToString();
                selectedCabinet = "0";
                Table_Cabinet.ItemsSource = db.Equipment.ToList();
            }
            else if (Cb_Cabinet_1.SelectedIndex == 1)
            {
                Monitor_Count.Text = db.Equipment.Where(db => db.indef == "MN" && db.cabinet == "1").Count().ToString();
                Chair_Count.Text = db.Equipment.Where(db => db.indef == "CR" && db.cabinet == "1").Count().ToString();
                Table_Count.Text = db.Equipment.Where(db => db.indef == "DK" && db.cabinet == "1").Count().ToString();
                Computer_Case_Count.Text = db.Equipment.Where(db => db.indef == "PC" && db.cabinet == "1").Count().ToString();
                selectedCabinet = "1";
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.cabinet == "1").ToList();
            }
            else if (Cb_Cabinet_1.SelectedIndex == 2)
            {
                Monitor_Count.Text = db.Equipment.Where(db => db.indef == "MN" && db.cabinet == "2").Count().ToString();
                Chair_Count.Text = db.Equipment.Where(db => db.indef == "CR" && db.cabinet == "2").Count().ToString();
                Table_Count.Text = db.Equipment.Where(db => db.indef == "DK" && db.cabinet == "2").Count().ToString();
                Computer_Case_Count.Text = db.Equipment.Where(db => db.indef == "PC" && db.cabinet == "2").Count().ToString();
                selectedCabinet = "2";
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.cabinet == "2").ToList();
            }
            else if (Cb_Cabinet_1.SelectedIndex == 3)
            {
                Monitor_Count.Text = db.Equipment.Where(db => db.indef == "MN" && db.cabinet == "3").Count().ToString();
                Chair_Count.Text = db.Equipment.Where(db => db.indef == "CR" && db.cabinet == "3").Count().ToString();
                Table_Count.Text = db.Equipment.Where(db => db.indef == "DK" && db.cabinet == "3").Count().ToString();
                Computer_Case_Count.Text = db.Equipment.Where(db => db.indef == "PC" && db.cabinet == "3").Count().ToString();
                selectedCabinet = "3";
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.cabinet == "3").ToList();
            }
        }
        private void Monitor_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCabinet != "0")
            {
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.cabinet == selectedCabinet && d.indef == "MN").ToList();
            }
            else
            {
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.indef == "MN").ToList();
            }
        }

        private void Table_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCabinet != "0")
            {
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.cabinet == selectedCabinet && d.indef == "DK").ToList();
            }
            else
            {
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.indef == "DK").ToList();
            }
        }

        private void Chair_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCabinet != "0")
            {
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.cabinet == selectedCabinet && d.indef == "CR").ToList();
            }
            else
            {
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.indef == "CR").ToList();
            }
        }

        private void Computer_Case_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCabinet != "0")
            {
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.cabinet == selectedCabinet && d.indef == "PC").ToList();
            }
            else
            {
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.indef == "PC").ToList();
            }
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
            db = new gr691_invert();
            //вывод таблицы
        }

    }
}
