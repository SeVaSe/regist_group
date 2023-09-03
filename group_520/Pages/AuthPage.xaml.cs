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

namespace group_520.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void TextBl_Changed(object sender, RoutedEventArgs e)
        {
            if (TxtBox_Log.Text.Length > 0)
            {
                TxtBl_Log.Visibility = Visibility.Collapsed;
            }
            else
            {
                TxtBl_Log.Visibility = Visibility.Visible;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PaswBox.SecurePassword.Length > 0)
            {
                TxtBl_Pasw.Visibility = Visibility.Collapsed;
            }
            else
            {
                TxtBl_Pasw.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBox_Log.Text) || string.IsNullOrEmpty(PaswBox.Password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка ввода");
                return;
            }
        }
    }
}
