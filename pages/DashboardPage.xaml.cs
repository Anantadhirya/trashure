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
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        private bool isSignedIn;
        private User user;
        Action<MainWindow.Navigation> Navigate;
        Action<object, RoutedEventArgs> NavigateItemClick;
        public DashboardPage(Action<MainWindow.Navigation> Navigate, Action<object, RoutedEventArgs> NavigateItemClick)
        {
            InitializeComponent();
            isSignedIn = true;
            user = new User { userID = 1, userName = "Ananta", password = "password1", address = "Bantul, D. I. Yogyakarta", phoneNumber = "123-456-7890", items = new List<Item>() };
            Item item1 = new Item { itemID = 1, owner = user, itemName = "AC Rusak", available = true, image = "/public/images/placeholder-1.jpg" };
            Item item2 = new Item { itemID = 2, owner = user, itemName = "Botol Bekas", available = true, image = "/public/images/placeholder-2.jpg" };
            user.items.Add(item1);
            user.items.Add(item2);
            updateSignedIn(isSignedIn, user);
            this.Navigate = Navigate;
            this.NavigateItemClick = NavigateItemClick;
        }
        private void updateSignedIn(bool isSignedIn, User user)
        {
            this.isSignedIn = isSignedIn;
            this.user = user;
            SignInRequired.Visibility = !isSignedIn ? Visibility.Visible : Visibility.Collapsed;
            Dashboard.Visibility = isSignedIn ? Visibility.Visible : Visibility.Collapsed;
            Username.Text = user?.userName;
            Gambar.Source = new BitmapImage(new Uri(user?.image != null ? user?.image : "pack://application:,,,/public/images/blank_profile.jpg"));
            BookListText.Visibility = Visibility.Collapsed;
            BookList.ItemsSource = user?.items;
        }
        private void NavigateSignIn(object sender, RoutedEventArgs e)
        {
            Navigate(MainWindow.Navigation.signin);
        }
        private void NavigateTambahSampah(object sender, RoutedEventArgs e)
        {
            Navigate(MainWindow.Navigation.tambahSampah);
        }
    }
}
