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

namespace DemTREN3
{
    /// <summary>
    /// Логика взаимодействия для Cabinet.xaml
    /// </summary>
    public partial class Cabinet : Window
    {
        public Cabinet()
        {
            InitializeComponent();
            Grid.ItemsSource = DemEntities.GetContext().Auto.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var _delete = Grid.SelectedItem as Auto;

                DemEntities.GetContext().Auto.Remove(_delete);
                DemEntities.GetContext().SaveChanges();

                MessageBox.Show("Удалено");

                Grid.ItemsSource = DemEntities.GetContext().Auto.ToList();
            }
        }
    }
}
