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
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        Action<User> SignIn;
        Action<MainWindow.Navigation> Navigate;
        public SignUpPage(Action<MainWindow.Navigation> Navigate, Action<User> SignIn)
        {
            InitializeComponent();
            this.Navigate = Navigate;
            this.SignIn = SignIn;
        }
        private bool check(string text, string type)
        {
            string errorMessage = "";
            if (text == "") errorMessage = type + " tidak boleh kosong.";
            else if (type == "Username")
            {
                using (var db = new TrashureContext())
                {
                    var query = from user in db.Users where user.userName == text select user;
                    if (query.Any()) errorMessage = "Username sudah digunakan.";
                }
            }

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            } 
            else return true;
        }

        private void signupbutton_onClick(object sender, RoutedEventArgs e)
        {
            if (check(Username.Text, "Username") && check(Password.Password, "Password") && check(ConfirmPassword.Password, "Confirm Password") && check(Alamat.Text, "Alamat") && check(Kontak.Text, "Nomor Telepon"))
            {
                if(Password.Password != ConfirmPassword.Password)
                {
                    MessageBox.Show("Password dan konfirmasi password tidak sesuai.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                using (var db = new TrashureContext())
                {
                    var user = new User { userName = Username.Text, password = HashHelper.HashPassword(Password.Password), phoneNumber = Kontak.Text, address = Alamat.Text };
                    db.Users.Add(user);
                    db.SaveChanges();
                    SignIn(user);
                    MessageBox.Show("Pendaftaran berhasil", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private void onEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                signupbutton_onClick(sender, null);
            }
        }

        private void onSignIn(object sender, MouseButtonEventArgs e)
        {
            Navigate(MainWindow.Navigation.signin);
        }
    }
}
