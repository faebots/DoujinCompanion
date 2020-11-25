using System;
using System.Collections.Generic;
using System.Text;

namespace DoujinDb.Models
{
    public class Doujinshi
    {
        public int? Id { get; set; }
        //
        public Dictionary<Language, string> Title { get; set; }
        public string CoverFilePath { get; set; }
        public string Description { get; set; }
        public Link PurchaseLink { get; set; }
        public decimal Price { get; set; }
        public int Length { get; set; }

        public Artist Artist { get; set; }
    }

    public enum Language
    {
        Japanese,
        Romaji,
        English
    }
}
