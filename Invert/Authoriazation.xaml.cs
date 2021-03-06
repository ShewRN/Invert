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
using Tulpep.NotificationWindow;
using Color = System.Drawing.Color;

namespace Invert
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        gr691_invert db;
        public MainWindow()
        {
            InitializeComponent();
            db = new gr691_invert();
        }

        private void Auth_Enter(object sender, RoutedEventArgs e)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Ошибка авторизации";
            popup.BodyColor = Color.LightGray;
            if (string.IsNullOrWhiteSpace(Auth_Login.Text) || string.IsNullOrWhiteSpace(Auth_Password.Password))
            {
                popup.ContentText = "Не все поля заполнены";
                popup.Popup();
                return;
            }
            var auth_check = db.User.FirstOrDefault(ch => ch.login == Auth_Login.Text && ch.password == Auth_Password.Password);
            if (auth_check == null)
            {
                popup.ContentText = "Логин или пароль введены не верно";
                popup.Popup();
                return;
            }
            else
            {
                Hide();
                new Invert_Cabinet().ShowDialog();
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

