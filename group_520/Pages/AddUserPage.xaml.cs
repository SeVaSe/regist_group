using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        private User _currentuser = new User();

        public AddUserPage(User selected)
        {
            InitializeComponent();
            if (selected != null)
            {
                _currentuser = selected;
            }

            DataContext = _currentuser;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AdminPage());
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            object cmbD = comboBoxEl.SelectedItem;
            bool flag = true;
            foreach (UIElement el in GridLogAdmin.Children)
            {
                if (el is TextBox txtBox && txtBox != TxtNameBox && string.IsNullOrEmpty(txtBox.Text))
                {
                    flag = false; 
                    break;
                }
            }

            if (flag == false || cmbD == null)
            {
                MessageBox.Show("Заполните все поля для регистрации!", "Ошибка заполненности", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (TxtBoxPasw.Text.Length >= 6)
                {
                    if (_currentuser.id == 0)
                    {
                        string selectedRole = comboBoxEl.SelectedValue as string;

                        User addUser = new User()
                        {
                            login = TxtBoxLog.Text,
                            password = TxtBoxPasw.Text,
                            role = comboBoxEl.Text,
                            fio = TxtBoxFio.Text
                        };
                        Entities1.GetEntities1().User.Add(addUser);


                        

                        try
                        {
                            Entities1.GetEntities1().SaveChanges();
                            MessageBox.Show("Данные успешно сохранены!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString() + $" {_currentuser}  |  {_currentuser.id}     ");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Слишком маленький пароль", "Ошибка пароля", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
