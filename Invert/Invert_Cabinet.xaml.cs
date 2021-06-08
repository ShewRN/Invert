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
using Tulpep.NotificationWindow;
using Color = System.Drawing.Color;

namespace Invert
{
    /// <summary>
    /// Логика взаимодействия для Invert_Cabinet.xaml
    /// </summary>
    public partial class Invert_Cabinet : Window
    {
        public gr691_invert db;
        Equip equip = new Equip();
        public Invert_Cabinet()
        {
            InitializeComponent();
            db = new gr691_invert();
            List<Equipment> us = db.Database.SqlQuery<Equipment>("Select*from Equipment Where indef = 'Монитор'").ToList();
            //Monitor_Count.Content = Convert.ToString(us.Count);
            us = db.Database.SqlQuery<Equipment>("Select*from Equipment Where indef = 'Стул'").ToList();

            us = db.Database.SqlQuery<Equipment>("Select*from Equipment Where indef = 'Стол'").ToList();
            Table_Count.Text = Convert.ToString(us.Count);
            us = db.Database.SqlQuery<Equipment>("Select*from Equipment Where indef = 'Компьютер'").ToList();
            List<Equipment> ps = db.Equipment.Where(db => db.indef == "Стул").ToList();
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
                Monitor_Count.Text = db.Equipment.Where(w => w.indef == "Монитор").Count().ToString();
                Chair_Count.Text = db.Equipment.Where(db => db.indef == "Стул").Count().ToString();
                Table_Count.Text = db.Equipment.Where(db => db.indef == "Стол").Count().ToString();
                Computer_Case_Count.Text = db.Equipment.Where(db => db.indef == "Компьютер").Count().ToString();
                selectedCabinet = "0";
                Table_Cabinet.ItemsSource = db.Equipment.ToList();
            }
            else if (Cb_Cabinet_1.SelectedIndex == 1)
            {
                Monitor_Count.Text = db.Equipment.Where(db => db.indef == "Монитор" && db.cabinet == "1").Count().ToString();
                Chair_Count.Text = db.Equipment.Where(db => db.indef == "Стул" && db.cabinet == "1").Count().ToString();
                Table_Count.Text = db.Equipment.Where(db => db.indef == "Стол" && db.cabinet == "1").Count().ToString();
                Computer_Case_Count.Text = db.Equipment.Where(db => db.indef == "Компьютер" && db.cabinet == "1").Count().ToString();
                selectedCabinet = "1";
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.cabinet == "1").ToList();
            }
            else if (Cb_Cabinet_1.SelectedIndex == 2)
            {
                Monitor_Count.Text = db.Equipment.Where(db => db.indef == "Монитор" && db.cabinet == "2").Count().ToString();
                Chair_Count.Text = db.Equipment.Where(db => db.indef == "Стул" && db.cabinet == "2").Count().ToString();
                Table_Count.Text = db.Equipment.Where(db => db.indef == "Стол" && db.cabinet == "2").Count().ToString();
                Computer_Case_Count.Text = db.Equipment.Where(db => db.indef == "Компьютер" && db.cabinet == "2").Count().ToString();
                selectedCabinet = "2";
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.cabinet == "2").ToList();
            }
            else if (Cb_Cabinet_1.SelectedIndex == 3)
            {
                Monitor_Count.Text = db.Equipment.Where(db => db.indef == "Монитор" && db.cabinet == "3").Count().ToString();
                Chair_Count.Text = db.Equipment.Where(db => db.indef == "Стул" && db.cabinet == "3").Count().ToString();
                Table_Count.Text = db.Equipment.Where(db => db.indef == "Стол" && db.cabinet == "3").Count().ToString();
                Computer_Case_Count.Text = db.Equipment.Where(db => db.indef == "Компьютер" && db.cabinet == "3").Count().ToString();
                selectedCabinet = "3";
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.cabinet == "3").ToList();
            }
        }
        private void Monitor_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCabinet != "0")
            {
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.cabinet == selectedCabinet && d.indef == "Монитор").ToList();
            }
            else
            {
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.indef == "Монитор").ToList();
            }
        }

        private void Table_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCabinet != "0")
            {
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.cabinet == selectedCabinet && d.indef == "Стол").ToList();
            }
            else
            {
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.indef == "Стол").ToList();
            }
        }

        private void Chair_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCabinet != "0")
            {
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.cabinet == selectedCabinet && d.indef == "Стул").ToList();
            }
            else
            {
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.indef == "Стул").ToList();
            }
        }

        private void Computer_Case_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCabinet != "0")
            {
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.cabinet == selectedCabinet && d.indef == "Компьютер").ToList();
            }
            else
            {
                Table_Cabinet.ItemsSource = db.Equipment.Where(d => d.indef == "Компьютер").ToList();
            }
        }
        //ВКЛАДКА РЕДАКТИРОВАНИЯ ТАБЛИЦЫ
        private void Insert(object sender, RoutedEventArgs e)
        {
            if (equip.Add(Cb_Equipment.SelectedIndex.ToString(), Cb_Cabinet_2.Text) == true)
            {
                Cb_Cabinet_2.SelectedIndex = -1;
                Cb_Equipment.SelectedIndex = -1;
            }
            Table_Editing.ItemsSource = db.Equipment.ToList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Equipment equipment = Table_Editing.SelectedItem as Equipment;
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Ошибка";
            popup.BodyColor = Color.LightGray;
            if (Table_Editing.SelectedItem == null)
            {
                popup.ContentText = "Вы не выбрали кабинет";
                popup.Popup();
                return;
            }
            db.Equipment.Where(i => i.id == equipment.id).FirstOrDefault();
            equip.Delete(equipment != null ? equipment.id.ToString() : "0");
            Table_Editing.ItemsSource = db.Equipment.ToList();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            Equipment equipment = Table_Editing.SelectedItem as Equipment;
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Ошибка";
            popup.BodyColor = Color.LightGray;
            if (Table_Editing.SelectedItem == null)
            {
                popup.ContentText = "Вы не выбрали кабинет";
                popup.Popup();
                return;
            }
            db.Equipment.Where(i => i.id == equipment.id).FirstOrDefault();
            if (equip.Update(equipment != null ? equipment.id.ToString() : "0", Cb_Equipment.SelectedIndex.ToString(), Cb_Cabinet_2.Text) == true)
            {
                gr691_invert db = new gr691_invert();
                Cb_Cabinet_2.SelectedIndex = -1;
                Cb_Equipment.SelectedIndex = -1;
                Table_Editing.ItemsSource = db.Equipment.ToList();
            }
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //ЗАГРУЗКА ДАННЫХ В ТАБЛИЦАХ
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new gr691_invert();
            Table_Editing.ItemsSource = db.Equipment.ToList();
        }
    }
}
