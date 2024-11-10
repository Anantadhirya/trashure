using Azure.Storage.Blobs.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        Action<object, RoutedEventArgs> NavigateItemClick;
        public HomePage(Action<object, RoutedEventArgs> NavigateItemClick)
        {
            InitializeComponent();
            this.NavigateItemClick = NavigateItemClick;

            using (var db = new TrashureContext())
            {
                var query = from i in db.Items.Include(i => i.owner) orderby i.itemID descending select i;
                ItemList.ItemsSource = query.Take(100).ToList();
            }
        }
        public void searchFilter(string searchText)
        {
            TextDaftarBarang.Text = string.IsNullOrEmpty(searchText) ? "Daftar Barang" : "Hasil Pencarian"; 
            using (var db = new TrashureContext())
            {
                var query = from i in db.Items.Include(i => i.owner) orderby i.itemID descending select i;
                
                var searchWords = searchText.Split(' ').Where(i => !string.IsNullOrEmpty(i));
                foreach (var word in searchWords)
                {
                    query = (IOrderedQueryable<Item>)query.Where(i => i.itemName.ToLower().Contains(word.ToLower()));
                }

                ItemList.ItemsSource = query.Take(100).ToList();
            }
        }
    }
}
