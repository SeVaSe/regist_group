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
using System.Windows.Threading;

namespace group_520
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += Window_Closing;

            DispatcherTimer time = new DispatcherTimer();
            time.Interval = TimeSpan.FromSeconds(1);
            time.Tick += Time_Tick;            
            time.Start();

        }

        private void Time_Tick(object sender, EventArgs e)
        {
            TextBlTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        // закрытие окна
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы точно хотите закрыть окно?", "Подтверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (res == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
