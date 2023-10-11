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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            var currentUser = Entities1.GetEntities1().User.ToList();
            ListUser.ItemsSource = currentUser;

            CmbBox_SortirovkaFIO.SelectedIndex = 0;
            CheckDriver.IsChecked = false;


        }

        private void UpdateUsers()
        {
            //загружаем всех пользователей в список
            var currentUsers = Entities1.GetEntities1().User.ToList();

            //осуществляем поиск по Ф.И.О. без учета регистра букв
            currentUsers = currentUsers.Where(x => x.fio.ToLower().Contains(TxtBox_FindFIO.Text.ToLower())).ToList();

            //обрабатываем фильтр по одной роли пользователей
            if (CheckDriver.IsChecked.Value)
                currentUsers = currentUsers.Where(x => x.role.Contains("admin")).ToList();

            //осуществляем сортировку в зависимости от выбора пользователя
            if (CmbBox_SortirovkaFIO.SelectedIndex == 0)
                ListUser.ItemsSource = currentUsers.OrderBy(x => x.fio).ToList();
            else ListUser.ItemsSource = currentUsers.OrderByDescending(x => x.fio).ToList();

        }

        private void TxtBox_FindFIO_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUsers();
        }

        private void CmbBox_SortirovkaFIO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUsers();
        }

        private void CheckDriver_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();
        }
        
        private void UnCheckDriver_UnChecked(object sender, RoutedEventArgs e)
        {
            UpdateUsers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TxtBox_FindFIO.Clear();
            CmbBox_SortirovkaFIO.Text = null;
            CheckDriver.IsChecked = false;
        }
    }
}
