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
using trashure.pages;

namespace trashure
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User user;
        public MainWindow()
        {
            InitializeComponent();
            user = null;
            Navigate(Navigation.home);
        }
        // User Functions
        private void SignIn(User user)
        {
            this.user = user;
            AuthMenu.Visibility = Visibility.Collapsed;
            ProfileMenu.Visibility = Visibility.Visible;
            Profile.Header = user.userName;
            using (var db = new TrashureContext())
            {
                if (user != null)
                {
                    db.Users.Attach(user);
                    db.Entry(user).Collection(u => u.items).Load();
                }
            }
            Navigate(Navigation.dashboard);
        }

        private void UpdateUser(User user)
        {
            this.user = user;
            if(user != null)
            {
                SignIn(user);
            }
            else
            {
                SignOut(null, null);
            }
        }

        private void SignOut(object sender, RoutedEventArgs e)
        {
            this.user = null;
            AuthMenu.Visibility = Visibility.Visible;
            ProfileMenu.Visibility = Visibility.Collapsed;
            Profile.Header = "";
            Navigate(Navigation.home);
        }

        // Navigation Functions
        public enum Navigation
        {
            back,
            home,
            dashboard,
            signin,
            signup,
            tambahSampah,
            editProfil,
        }
        HomePage homepage;
        public void Navigate(Navigation target)
        {
            switch (target)
            {
                case Navigation.back:
                    if(mainFrame.CanGoBack) mainFrame.GoBack();
                    break;
                case Navigation.home:
                    homepage = new HomePage(NavigateItemClick);
                    mainFrame.Navigate(homepage);
                    break;
                case Navigation.dashboard:
                    mainFrame.Navigate(new DashboardPage(user, Navigate, NavigateItemClick));
                    break;
                case Navigation.signin:
                    mainFrame.Navigate(new SignInPage(Navigate, SignIn));
                    break;
                case Navigation.signup:
                    mainFrame.Navigate(new SignUpPage(Navigate, SignIn));
                    break;
                case Navigation.tambahSampah:
                    mainFrame.Navigate(new TambahSampahPage(Navigate, user));
                    break;
                case Navigation.editProfil:
                    mainFrame.Navigate(new EditProfilePage(user, Navigate, UpdateUser));
                    break;
            }
        }

        // Navigation Click Functions
        private void NavigateHome(object sender, RoutedEventArgs e)
        {
            Navigate(Navigation.home);
        }
        private void NavigateDashboard(object sender, RoutedEventArgs e)
        {
            Navigate(Navigation.dashboard);
        }
        private void NavigateSignIn(object sender, RoutedEventArgs e)
        {
            Navigate(Navigation.signin);
        }
        private void NavigateSignUp(object sender, RoutedEventArgs e)
        {
            Navigate(Navigation.signup);
        }
        private void NavigateEditProfile(object sender, RoutedEventArgs e)
        {
            Navigate(Navigation.editProfil);
        }
        private void NavigateItemClick(object sender, RoutedEventArgs e)
        {
            if(sender is Button button && button.DataContext is Item clickedItem)
            {
                if(user != null && clickedItem.owner.userID == user.userID)
                {
                    mainFrame.Navigate(new EditSampahPage(clickedItem, Navigate));
                } else
                {
                    mainFrame.Navigate(new KeteranganSampahPage(user, clickedItem, Navigate));
                }
            }
        }

        // Search bar functions
        private void onTextChanged(object sender, TextChangedEventArgs e)
        {
            ClearButton.Visibility = string.IsNullOrEmpty(SearchText.Text) ? Visibility.Collapsed : Visibility.Visible;
        }
        private void onSearchEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Navigate(Navigation.home);
                homepage.searchFilter(SearchText.Text);
            }
        }

        private void onSearchGotFocus(object sender, RoutedEventArgs e)
        {
            SearchPlaceholder.Visibility = Visibility.Collapsed;
        }
        private void onSearchLostFocus(object sender, RoutedEventArgs e)
        {
            SearchPlaceholder.Visibility = string.IsNullOrEmpty(SearchText.Text) ? Visibility.Visible : Visibility.Collapsed;
        }
        private void onClear(object sender, RoutedEventArgs e)
        {
            SearchText.Text = "";
            onSearchLostFocus(sender, null);
            homepage.searchFilter(SearchText.Text);
        }
    }
}
