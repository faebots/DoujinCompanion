using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DoujinDb.Models
{
    public class Book : Model
    {
        public Book()
        {
            Title = new Dictionary<Language, string>();
            Tags = new List<Tag>();
        }

        public override int? Id { get; set; }
        public Dictionary<Language, string> Title { get; set; }
        public string CoverFilePath { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Length { get; set; }
        public bool R18 { get; set; }

        public Link PurchaseLink { get; set; }
        public Artist Artist { get; set; }
        public BookType Type { get; set; }
        public List<Tag> Tags { get; set; }

        internal override Entities.Entity ToEntity()
        {
            var e = new Entities.Book
            {
                CoverFilePath = CoverFilePath,
                Description = Description,
                Price = Convert.ToDouble(Price),
                Length = Length,
                R18 = R18
            };
            if (Id.HasValue)
                e.Id = Id.Value;
            if (PurchaseLink != null && PurchaseLink.Id.HasValue)
                e.PurchaseLinkId = PurchaseLink.Id.Value;
            if (Artist != null && Artist.Id.HasValue)
                e.ArtistId = Artist.Id.Value;
            if (Type != null && Type.Id.HasValue)
                e.BookTypeId = Type.Id.Value;
            return e;
        }

        internal override int Save(DataAccess db)
        {
            var e = this.ToEntity();
            int rows = 0;
            if (!Id.HasValue)
            {
                db.Insert(e);
                Id = e.Id;
            }

            if (PurchaseLink != null)
                rows += PurchaseLink.Save(db);
            if (Artist != null)
                rows += Artist.Save(db);
            if (Type != null)
                rows += Type.Save(db);

            rows += db.Update(e);

            rows += Tags.Aggregate(rows, (i, t) => i += SaveRelations(t, db));
            rows += Title.Keys.Aggregate(rows, (i, t) => i += SaveRelations(t, db));

            return rows;
        }

        private int SaveRelations(Tag tag, DataAccess db)
        {
            var newRelation = !tag.Id.HasValue;
            var rows = tag.Save(db);
            if (newRelation)
                rows += db.Insert(new Entities.BookTag
                {
                    BookId = Id.Value,
                    TagId = tag.Id.Value
                });
            return rows;
        }

        private int SaveRelations(Language lang, DataAccess db)
        {
            var e = db.GetTitles(this.ToEntity() as Entities.Book, lang);
            if (e == null)
            {
                e = new Entities.Title
                {
                    BookId = Id.Value,
                    Language = lang,
                    Name = Title[lang]
                };
                return db.Insert(e);
            }
            if (e.Name != Title[lang])
                return db.Update(e);
            return 0;
        }

    }
}
