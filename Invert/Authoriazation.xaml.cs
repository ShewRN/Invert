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
        Model1Container db;
        public MainWindow()
        {
            InitializeComponent();
            db = new Model1Container();
        }

        private void Auth_Enter(object sender, RoutedEventArgs e)
        {
            var authorization = db.Users.FirstOrDefault(l => l.login_u == Auth_Login.Text && l.password_u == Auth_Password.Password);
            Meth_Auth meth_auth = new Meth_Auth();
            if (meth_auth.Enter(Auth_Login.Text, Auth_Password.Password) == true)
            {
                switch (authorization.id_role)
                {
                    case 1:
                        MessageBox.Show("Вход выполнен", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                        Hide();
                        new Admin_Home().ShowDialog();
                        Application.Current.Shutdown();
                        break;
                    case 2:
                        MessageBox.Show("Вход выполнен", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                        Hide();
                        new Manager_Home().ShowDialog();
                        Application.Current.Shutdown();
                        break;
                    case 3:
                        MessageBox.Show("Вход выполнен", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                        Hide();
                        usr = authorization;
                        new Windows.Teacher_Schedule().ShowDialog();
                        Application.Current.Shutdown();
                        break;
                }
            }
        }

    }
}
