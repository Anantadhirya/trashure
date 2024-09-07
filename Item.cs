using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trashure
{
    class Item
    {
        private int _itemID;
        private string _itemName;
        private string _itemDescription;
        private double _itemPrice;
        private int _itemStock;

        public void addItem(int itemID, string itemName, string itemDescription, double itemprice, int itemStock)
        {
            _itemID = itemID;
            _itemName = itemName;
            _itemDescription = itemDescription;
            _itemPrice = itemprice;
            _itemStock = itemStock;
        }

        public void updateItem(string itemName, string itemDescription, double itemPrice, int itemStock)
        {
            _itemName = itemName;
            _itemDescription = itemDescription;
            _itemPrice = itemPrice;
            _itemStock = itemStock;
        }

        public void deleteItem()
        {
            _itemID = 0;
            _itemName = null;
            _itemDescription = null;
            _itemPrice = 0.0;
            _itemStock = 0;
        }
    }
}
