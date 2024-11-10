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
    /// Interaction logic for KeteranganSampahPage.xaml
    /// </summary>
    public partial class KeteranganSampahPage : Page
    {
        Item item;
        User user;
        Action<MainWindow.Navigation> Navigate;
        public KeteranganSampahPage(User user, Item item, Action<MainWindow.Navigation> Navigate)
        {
            InitializeComponent();
            this.user = user;
            this.item = item;
            this.Navigate = Navigate;
            Judul.Text = item.itemName;
            Gambar.Source = item.image != null ? new BitmapImage(new Uri(item.image, UriKind.RelativeOrAbsolute)) : null;
            Owner.Text = item.owner.userName;
            GambarPemilik.Source = new BitmapImage(new Uri(item.owner != null && item.owner.image != null ? item.owner.image : "pack://application:,,,/public/images/blank_profile.jpg"));
            NamaPemilik.Text = item.owner.userName;
            KontakPemilik.Text = item.owner.phoneNumber;
            LokasiPemilik.Text = item.owner.address;
            updateStatusItem();
        }
        private void updateStatusItem()
        {
            if (item.available)
            {
                Status.Text = "Tersedia";
                Status.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                Status.Text = "Tidak Tersedia";
                Status.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void NavigateSignIn(object sender, RoutedEventArgs e)
        {
            Navigate(MainWindow.Navigation.signin);
        }

        private void onKontak(object sender, RoutedEventArgs e)
        {
            var isSignedIn = (user != null);
            SignInRequired.Visibility = isSignedIn ? Visibility.Collapsed : Visibility.Visible;
            KeteranganSampah.Visibility = isSignedIn ? Visibility.Visible: Visibility.Collapsed;
            if (isSignedIn) KeteranganKontak.Visibility = Visibility.Visible;
        }

        private void CloseUserWindow(object sender, RoutedEventArgs e)
        {
            KeteranganKontak.Visibility = Visibility.Collapsed;
        }
    }
}
