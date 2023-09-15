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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        // кнопка назад
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AuthPage());
        }

        /*ОБРАБОТЧИК ПУСТЫХ ПОЛЕЙ
         Работает след образом: мы обращаемся к имени грида, находим все элементы текстового поля
        и бежим по ним. Если они пустые цикл прекращается и flag становится FALSE, после чего условие
        проверяет flag и выводит соотвествующее сообщение*/
        private void Button_Click_Registr(object sender, RoutedEventArgs e)
        {
            bool flag = true;
            object rolePanelObj = comboBoxEl.SelectedItem;


            foreach (UIElement el in inputGrid.Children) 
            { 
                if (el is TextBox txtBox && string.IsNullOrEmpty(txtBox.Text))
                {
                    flag = false;
                    break;
                }
            }

            if (flag==false || rolePanelObj == null) 
            { 
                MessageBox.Show("Заполните все поля для регистрации!", "Ошибка заполненности", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                using (var db = new Entities1())
                {
                    var user = db.User
                    .AsNoTracking()
                    .FirstOrDefault();

                    if (user.login == LoginTxtBox.Text)
                    {
                        MessageBox.Show("Такой логин уже существует. Придумайте новый", "Существующий логин", MessageBoxButton.OK, MessageBoxImage.Warning);
                        LoginTxtBox.Clear();
                    }
                    else
                    {
                        if (TxtPasword.Text.Length >= 6)
                        {
                            if (TxtPaswordSecure.Text == TxtPasword.Text)
                            {
                                User userObject = new User()
                                {
                                    login = LoginTxtBox.Text,
                                    password = TxtPasword.Text,
                                    role = comboBoxEl.Text,
                                    fio = TxtBoxFio.Text
                                };
                                db.User.Add(userObject);
                                db.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show("Не совпадают пароли, проверьте заново и повторите ваши действия", "Ошибка проверки пароля", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Слишком маленький пароль", "Маленький пароль", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }
    }
}
