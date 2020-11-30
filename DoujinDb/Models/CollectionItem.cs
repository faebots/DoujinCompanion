using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DoujinDb.Models
{
    public class CollectionItem : Model
    {
        public CollectionItem()
        {
            Scans = new List<Scan>();
        }

        public override int? Id { get; set; }
        public Book Book { get; set; }
        public List<Scan> Scans { get; set; }
        public Status TranslationStatus { get; set; }
        public int TranslatedPages { get; set; }
        public Status ReadStatus { get; set; }
        public int ReadPages { get; set; }
        public DateTime Added { get; set; }
        public DateTime Updated { get; set; }
        public bool HardCopy { get; set; }

        internal override Entities.Entity ToEntity()
        {
            var e = new Entities.Collection
            {
                TranslatedPages = TranslatedPages,
                ReadPages = ReadPages,
                Added = Added,
                Updated = Updated,
                HardCopy = HardCopy
            };
            if (Id.HasValue)
                e.Id = Id.Value;
            if (Book != null && Book.Id.HasValue)
                e.BookId = Book.Id.Value;
            if (TranslationStatus != null && TranslationStatus.Id.HasValue)
                e.TranslationStatus = TranslationStatus.Id.Value;
            if (ReadStatus != null && ReadStatus.Id.HasValue)
                e.ReadStatus = ReadStatus.Id.Value;

            return e;
        }

        internal override int Save(DataAccess db)
        {
            var rows = 0;
            var e = this.ToEntity();
            if (!Id.HasValue)
            {
                db.Insert(e);
                Id = e.Id;
            }

            if (Book != null)
                rows += Book.Save(db);
            if (TranslationStatus != null)
                rows += TranslationStatus.Save(db);
            if (ReadStatus != null)
                rows += ReadStatus.Save(db);

            rows += Scans.Aggregate(rows, (i, s) => i += s.Save(db));

            return rows;
        }
    }
}
