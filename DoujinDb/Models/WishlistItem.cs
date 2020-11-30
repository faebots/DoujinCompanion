using System;
using System.Collections.Generic;
using System.Text;

namespace DoujinDb.Models
{
    public class WishlistItem
    {
        public int? Id { get; set; }
        public Book Doujin { get; set; }
        public Dictionary<string, Link> PurchaseLinks { get; set; }
        public Dictionary<string, int> Prices { get; set; }
        public bool RestockAlert { get; set; }
    }
}
