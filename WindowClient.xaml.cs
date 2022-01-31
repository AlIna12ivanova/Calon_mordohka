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
using System.Windows.Shapes;

namespace Calon_mordohka
{
    /// <summary>
    /// Логика взаимодействия для WindowClient.xaml
    /// </summary>
    public partial class WindowClient : Window
    {
        Calon_mordohkaEntities1 context;
        public WindowClient(Calon_mordohkaEntities1 context, ClientService2 clientService2)
        {
            InitializeComponent();
            CmbClient.ItemsSource = context.Clients.ToList();
            CmbService.ItemsSource = context.Services.ToList();
            this.DataContext = clientService2;
        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            this.Close();
        }
    }
}
