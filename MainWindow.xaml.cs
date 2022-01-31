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

namespace Calon_mordohka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calon_mordohkaEntities1 context;
        public MainWindow()
        {
            InitializeComponent();
            context = new Calon_mordohkaEntities1();
            ShowTable();
            
        }
        private void ShowTable()
        {
            DataCalon.ItemsSource = context.ClientService2.ToList();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewClient = new ClientService2();
            context.ClientService2.Add(NewClient);
            var NewWind = new WindowClient(context, NewClient);
            NewWind.ShowDialog();
            ShowTable();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentClientService2 = DataCalon.SelectedItem as ClientService2;
            if (currentClientService2 == null)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы хотите удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.ClientService2.Remove(currentClientService2);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void DataCalon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentClientService2 = BtnEdit.DataContext as ClientService2;
            var EditWindow = new WindowClient(context, currentClientService2);
            EditWindow.ShowDialog();
        }
    }
}
