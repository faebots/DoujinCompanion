using System;
using System.Collections.Generic;
using System.Text;

namespace DoujinDb.Models
{
    public class CollectionItem
    {
        public int? Id { get; set; }
        public Doujinshi Doujin { get; set; }
        public Status ScanStatus { get; set; }
        public Status TranslationStatus { get; set; }
        public int TranslatedPages { get; set; }
        public Status ReadStatus { get; set; }
        public int ReadPages { get; set; }
        public string FilePath { get; set; }
        public Link ScanShare { get; set; }
        public DateTime Added { get; set; }
        public DateTime Updated { get; set; }
    }
}
