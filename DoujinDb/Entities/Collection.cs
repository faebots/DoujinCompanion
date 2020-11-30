using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;

namespace DoujinDb.Entities
{
    class Collection : Entity
    {
        [PrimaryKey, AutoIncrement]
        public override int Id { get; set; }
        [Indexed]
        public int BookId { get; set; }
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
        public bool HardCopy { get; set; }

        public Models.CollectionItem ToModel()
        {
            return new Models.CollectionItem
            {
                Id = Id,
                TranslatedPages = TranslatedPages,
                ReadPages = ReadPages,
                Added = Added,
                Updated = Updated,
                HardCopy = HardCopy
            };
        }

        public Models.CollectionItem ToModel(DataAccess db)
        {
            var model = ToModel();
            model.Book = db.GetBooks(BookId).ToModel();
            model.Scans = db.GetScansByCollection(Id).Select(s => s.ToModel()).ToList();
            return model;
        }

        public Models.CollectionItem ToModelDeep(DataAccess db)
        {
            var model = ToModel(db);
            model.Book = db.GetBooks(BookId).ToModelDeep(db);
            return model;
        }
    }
}
