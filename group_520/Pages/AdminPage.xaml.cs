﻿using System;
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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            DataGridUser.ItemsSource = Entities1.GetEntities1().User.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddUserPage(null));
        }

        private void But_Redactor(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddUserPage((sender as Button).DataContext as User));
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = DataGridUser.SelectedItems.Cast<User>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {usersForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities1.GetEntities1().User.RemoveRange(usersForRemoving);
                    Entities1.GetEntities1().SaveChanges();
                    MessageBox.Show("Данные успешно удалены");
                    DataGridUser.ItemsSource = Entities1.GetEntities1().User.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }

        }
    }
}
