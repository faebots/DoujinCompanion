using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    public class Doujinshi
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string CoverFilePath { get; set; } 
        public string Description { get; set; } 
        public double Price { get; set; }
        public int Length { get; set; } 
        [Indexed]
        public int PurchaseLinkId { get; set; }
        [Indexed]
        public int ArtistId { get; set; }
    }
}
