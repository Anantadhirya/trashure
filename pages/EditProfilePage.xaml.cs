using Microsoft.Win32;
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
    /// Interaction logic for EditProfilePage.xaml
    /// </summary>
    public partial class EditProfilePage : Page
    {
        User user;
        private string imagePath = "";
        private Action<MainWindow.Navigation> Navigate;
        private Action<User> UpdateUser;
        public EditProfilePage(User user, Action<MainWindow.Navigation> Navigate, Action<User> UpdateUser)
        {
            InitializeComponent();
            this.user = user;
            this.Navigate = Navigate;
            this.UpdateUser = UpdateUser;
            initDefaultValue();
        }
        public void initDefaultValue()
        {
            Username.Text = user.userName;
            Kontak.Text = user.phoneNumber;
            Alamat.Text = user.address;
            Gambar.Source = new BitmapImage(new Uri(user.image != null ? user.image : "pack://application:,,,/public/images/blank_profile.jpg"));
        }

        private void onUbahGambar(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                imagePath = openFileDialog.FileName;
                Gambar.Source = new BitmapImage(new Uri(imagePath));
            }
        }

        private void onHapusGambar(object sender, RoutedEventArgs e)
        {
            imagePath = null;
            Gambar.Source = new BitmapImage(new Uri("pack://application:,,,/public/images/blank_profile.jpg"));
        }

        private bool check(string text, string type)
        {
            string errorMessage = "";
            if (text == "") errorMessage = type + " tidak boleh kosong.";
            else if (type == "Username")
            {
                using (var db = new TrashureContext())
                {
                    var query = from user in db.Users where user.userName == text && user.userID != this.user.userID select user;
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

        private async void onSave(object sender, RoutedEventArgs e)
        {
            if (check(Username.Text, "Username") && check(Kontak.Text, "Nomor Telepon") && check(Alamat.Text, "Alamat"))
            {
                using (var db = new TrashureContext())
                {
                    db.Users.Attach(user);
                    user.userName = Username.Text;
                    user.phoneNumber = Kontak.Text;
                    user.address = Alamat.Text;
                    if (imagePath == null)
                    {
                        user.image = null;
                    }
                    else if (imagePath != "")
                    {
                        string imageUrl = await storage.UploadImage(imagePath);
                        user.image = imageUrl;
                    }
                    db.SaveChanges();
                    MessageBox.Show("Perubahan Disimpan", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    UpdateUser(user);
                }
            }
        }
        private void HapusAkun(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Apakah Anda yakin ingin menghapus akun Anda?", "Penghapusan Akun", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new TrashureContext())
                {
                    db.Users.Attach(user);
                    db.Users.Remove(user);

                    db.Entry(user).Collection(u => u.items).Load();
                    var itemsToDelete = user.items;
                    db.Items.RemoveRange(itemsToDelete);

                    db.SaveChanges();
                    UpdateUser(null);
                    Navigate(MainWindow.Navigation.signin);
                    MessageBox.Show("Akun berhasil dihapus", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private void Back(object sender, MouseButtonEventArgs e)
        {
            Navigate(MainWindow.Navigation.back);
        }
    }
}
