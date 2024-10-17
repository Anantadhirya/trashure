using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trashure
{
    class Item
    {
        public int itemID { get; set; }
        public User owner { get; set; }
        public string itemName { get; set; }
        public bool available { get; set; }
        public string image {  get; set; }
    }
}
