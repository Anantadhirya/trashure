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

namespace trashure.pages
{
    /// <summary>
    /// Interaction logic for EditSampahPage.xaml
    /// </summary>
    public partial class EditSampahPage : Page
    {
        Item item;
        Action<MainWindow.Navigation> Navigate;
        public EditSampahPage(Item item, Action<MainWindow.Navigation> Navigate)
        {
            InitializeComponent();
            this.item = item;
            this.Navigate = Navigate;
        }

        private void onUbahGambar(object sender, RoutedEventArgs e)
        {

        }

        private void HapusSampah(object sender, RoutedEventArgs e)
        {

        }

        private void onSave(object sender, RoutedEventArgs e)
        {

        }
    }
}
