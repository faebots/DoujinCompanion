using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    public class Collection
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int DoujinId { get; set; }
        [Indexed]
        public int ScanStatus { get; set; }
        [Indexed]
        public int TranslationStatus { get; set; }
        public int TranslatedPages { get; set; }
        [Indexed]
        public int ReadStatus { get; set; }
        public int ReadPages { get; set; }
        public string FilePath { get; set; }
        [Indexed]
        public int ScanShareLinkId { get; set; }
        public DateTime Added { get; set; }
        public DateTime Updated { get; set; }
    }
}
