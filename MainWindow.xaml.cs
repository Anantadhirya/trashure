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
using trashure.pages;

namespace trashure
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigate(Navigation.signin);
        }
        public enum Navigation
        {
            back,
            home,
            dashboard,
            signin,
            signup,
            tambahSampah,
            keteranganSampah,
            editSampah,
            editProfil,
        }
        public void Navigate(Navigation target)
        {
            switch (target)
            {
                case Navigation.back:
                    if(mainFrame.CanGoBack) mainFrame.GoBack();
                    break;
                case Navigation.home:
                    mainFrame.Navigate(new HomePage());
                    break;
                case Navigation.dashboard:
                    mainFrame.Navigate(new DashboardPage(Navigate));
                    break;
                case Navigation.signin:
                    mainFrame.Navigate(new SignInPage());
                    break;
                case Navigation.signup:
                    mainFrame.Navigate(new SignUpPage());
                    break;
                case Navigation.tambahSampah:
                    mainFrame.Navigate(new TambahSampahPage());
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

        // Search bar functions
        private void onTextChanged(object sender, TextChangedEventArgs e)
        {
            ClearButton.Visibility = string.IsNullOrEmpty(SearchText.Text) ? Visibility.Collapsed : Visibility.Visible;
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
        }
    }
}
