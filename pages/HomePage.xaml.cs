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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        Action<object, RoutedEventArgs> NavigateItemClick;
        public HomePage(Action<object, RoutedEventArgs> NavigateItemClick)
        {
            InitializeComponent();
            this.NavigateItemClick = NavigateItemClick;

            // Placeholder data
            User user1 = new User { userID = 1, userName = "Ananta", password = "password1", address = "Bantul, D. I. Yogyakarta", phoneNumber = "123-456-7890" };
            User user2 = new User { userID = 2, userName = "Rama", password = "password2", address = "Yogyakarta", phoneNumber = "987-654-3210" };

            Item item1 = new Item { itemID = 1, owner = user1, itemName = "AC Rusak", available = true, image="/public/images/placeholder-1.jpg" };
            Item item2 = new Item { itemID = 2, owner = user2, itemName = "Botol Bekas", available = true, image = "/public/images/placeholder-2.jpg" };
            Item item3 = new Item { itemID = 3, owner = user1, itemName = "Jerigen", available = true, image = "/public/images/placeholder-3.jpg" };

            ItemList.ItemsSource = new List<Item>{ item1, item2, item3 };
        }
    }
}
