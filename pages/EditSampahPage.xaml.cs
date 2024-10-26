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
    /// Interaction logic for EditSampahPage.xaml
    /// </summary>
    public partial class EditSampahPage : Page
    {
        Item item;
        Action<MainWindow.Navigation> Navigate;
        private string imagePath = "";
        public EditSampahPage(Item item, Action<MainWindow.Navigation> Navigate)
        {
            InitializeComponent();
            this.item = item;
            this.Navigate = Navigate;
            initDefaultValue();
        }
        public void initDefaultValue()
        {
            NamaBarang.Text = item.itemName;
            Gambar.Source = item.image != null ? new BitmapImage(new Uri(item.image, UriKind.RelativeOrAbsolute)) : null;
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

        private void HapusSampah(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Apakah Anda yakin ingin menghapus barang ini?", "Penghapusan Barang", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new TrashureContext())
                {
                    db.Items.Attach(item);
                    db.Items.Remove(item);
                    db.SaveChanges();
                    Navigate(MainWindow.Navigation.dashboard);
                    MessageBox.Show("Barang berhasil dihapus", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void displayError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private async void onSave(object sender, RoutedEventArgs e)
        {
            if (NamaBarang.Text == "")
            {
                displayError("Nama barang tidak boleh kosong.");
                return;
            }
            using (var db = new TrashureContext())
            {
                db.Items.Attach(item);
                item.itemName = NamaBarang.Text;
                if (imagePath != "")
                {
                    string imageUrl = await storage.UploadImage(imagePath);
                    item.image = imageUrl;
                }
                db.SaveChanges();
                MessageBox.Show("Perubahan Disimpan", "", MessageBoxButton.OK, MessageBoxImage.Information);
                Navigate(MainWindow.Navigation.dashboard);
            }
        }
    }
}
