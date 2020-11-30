using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;

namespace DoujinDb.Entities
{
    class Book : Entity
    {
        [PrimaryKey, AutoIncrement]
        public override int Id { get; set; }
        public string CoverFilePath { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public double Price { get; set; }
        public int Length { get; set; }
        public bool R18 { get; set; }
        [Indexed]
        public int PurchaseLinkId { get; set; }
        [Indexed]
        public int ArtistId { get; set; }
        [Indexed]
        public int BookTypeId { get; set; }

        public Models.Book ToModel()
        {
            return new Models.Book
            {
                Id = Id,
                CoverFilePath = CoverFilePath,
                Description = Description,
                Price = Convert.ToDecimal(Price),
                Length = Length,
                R18 = R18
            };
        }

        public Models.Book ToModel(DataAccess db)
        {
            var model = ToModel();
            model.PurchaseLink = db.GetLinks(PurchaseLinkId)?.ToModel();
            model.Artist = db.GetArtists(this.ArtistId)?.ToModel();
            model.Type = db.GetBookTypes(this.BookTypeId)?.ToModel();
            model.Tags = db.GetTagsByBook(this).Select(t => t?.ToModel()).ToList();
            model.Title = db.GetTitles(this).ToDictionary(t => t.Language, t => t.Name);
            return model;
        }

        public Models.Book ToModelDeep(DataAccess db)
        {
            var model = ToModel(db);
            model.Artist = db.GetArtists(this.ArtistId)?.ToModel(db);
            return model;
        }
    }
}
