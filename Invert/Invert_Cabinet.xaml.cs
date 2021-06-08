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
using Tulpep.NotificationWindow;
using Color = System.Drawing.Color;

namespace Invert
{
    /// <summary>
    /// Логика взаимодействия для Invert_Cabinet.xaml
    /// </summary>
    public partial class Invert_Cabinet : Window
    {
        Equip equip = new Equip();
        public gr691_invert db;
        public Invert_Cabinet()
        {
            InitializeComponent();
            db = new gr691_invert();
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
            //MessageBox.Show(db.User.id)
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
