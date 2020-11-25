using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    public class Link
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string DisplayName { get; set; }
        [MaxLength(255)]
        public string Url { get; set; }
        public int Type { get; set; }
    }
}