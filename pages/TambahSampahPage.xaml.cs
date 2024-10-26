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
    /// Interaction logic for TambahSampahPage.xaml
    /// </summary>
    public partial class TambahSampahPage : Page
    {
        private User user;
        private Action<MainWindow.Navigation> Navigate;
        private string imagePath = "";
        public TambahSampahPage(Action<MainWindow.Navigation> Navigate, User user)
        {
            InitializeComponent();
            this.user = user;
            this.Navigate = Navigate;
        }

        private void onTambahGambar(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                imagePath = openFileDialog.FileName;
                Gambar.Source = new BitmapImage(new Uri(imagePath));
            }
        }
        private void displayError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private async void onTambahBarang(object sender, RoutedEventArgs e)
        {
            if(Nama.Text == "")
            {
                displayError("Nama barang tidak boleh kosong");
                return;
            }
            if(imagePath == "")
            {
                displayError("Gambar barang tidak boleh kosong");
                return;
            }
            using (var db = new TrashureContext())
            {
                db.Users.Attach(user);
                string imageUrl = await storage.UploadImage(imagePath);
                var item = new Item { itemName = Nama.Text, owner = user, image = imageUrl, available = true };
                db.Items.Add(item);
                db.SaveChanges();
                Navigate(MainWindow.Navigation.dashboard);
                MessageBox.Show("Penambahan barang berhasil", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
