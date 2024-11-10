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
using trashure.components;

namespace trashure.pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        User user;
        Action<MainWindow.Navigation> Navigate;
        Action<object, RoutedEventArgs> NavigateItemClick;
        public DashboardPage(User user, Action<MainWindow.Navigation> Navigate, Action<object, RoutedEventArgs> NavigateItemClick)
        {
            InitializeComponent();
            updateSignedIn(user);
            this.Navigate = Navigate;
            this.NavigateItemClick = NavigateItemClick;
        }
        private void updateSignedIn(User user)
        {
            bool isSignedIn = user != null;
            this.user = user;
            SignInRequired.Visibility = !isSignedIn ? Visibility.Visible : Visibility.Collapsed;
            Dashboard.Visibility = isSignedIn ? Visibility.Visible : Visibility.Collapsed;
            Username.Text = user?.userName;
            Gambar.Source = new BitmapImage(new Uri(user?.image != null ? user?.image : "pack://application:,,,/public/images/blank_profile.jpg"));
            ItemListText.Visibility = Visibility.Collapsed;
            user.items.Clear();
            using (var db = new TrashureContext())
            {
                if (user != null)
                {
                    db.Users.Attach(user);
                    db.Entry(user).Collection(u => u.items).Load();
                }
            }
            ItemList.ItemsSource = user?.items;
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
