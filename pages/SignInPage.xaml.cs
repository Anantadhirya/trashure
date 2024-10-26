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
    /// Interaction logic for SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        Action<User> SignIn;
        Action<MainWindow.Navigation> Navigate;
        public SignInPage(Action<MainWindow.Navigation> Navigate, Action<User> SignIn)
        {
            InitializeComponent();
            this.Navigate = Navigate;
            this.SignIn = SignIn;
        }

        private void displayError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void signinbutton_onClick(object sender, RoutedEventArgs e)
        {
            if (Username.Text == "")
            {
                displayError("Username tidak boleh kosong.");
                return;
            }
            if (Password.Password == "")
            {
                displayError("Password tidak boleh kosong.");
                return;
            }
            using (var db = new TrashureContext())
            {
                var query = from user in db.Users
                            where user.userName == Username.Text
                            select user;
                if (!query.Any())
                {
                    displayError("Username tidak ditemukan.");
                    return;
                }
                if (!HashHelper.VerifyPassword(Password.Password, query.First().password))
                {
                    displayError("Password salah.");
                    return;
                }
                SignIn(query.First());
                MessageBox.Show("Sign In berhasil", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void onEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                signinbutton_onClick(sender, null);
            }
        }
        private void onSignUp(object sender, MouseButtonEventArgs e)
        {
            Navigate(MainWindow.Navigation.signup);
        }
    }
}
