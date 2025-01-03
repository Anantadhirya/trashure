﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trashure
{
    public class User
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public virtual List<Item> items { get; set; }
        public string image {  get; set; }
    }
}
