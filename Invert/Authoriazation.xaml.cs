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

namespace Invert
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database1Entities db;
        public MainWindow()
        {
            InitializeComponent();
            db = new Database1Entities();
        }

        private void Auth_Enter(object sender, RoutedEventArgs e)
        {
            if (Auth_Login.Text == "" || Auth_Password.Password == "")
            {
                MessageBox.Show("Вы не заполнили все поля", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var auth_check = db.Users.FirstOrDefault(ch => ch.login == Auth_Login.Text && ch.password == Auth_Password.Password);
            if (auth_check == null)
            {
                MessageBox.Show("Логин или пароль введены не верно", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                MessageBox.Show("Вход выполнен", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                Hide();
                new Invert_Cabinet().ShowDialog();
                Application.Current.Shutdown();
            }
        }
    }
}
