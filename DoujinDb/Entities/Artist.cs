using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    class Artist : Entity
    {
        [PrimaryKey, AutoIncrement]
        public override int Id { get; set; }
        public string Name { get; set; }
        
        public Models.Artist ToModel()
        {
            return new Models.Artist
            {
                Id = Id,
                Name = Name
            };
        }

        public Models.Artist ToModel(DataAccess db)
        {
            var model = this.ToModel();
            model.Links = db.GetLinksByArtist(this).Select(l => l.ToModel()).ToList();
            return model;
        }

        public int Delete(DataAccess db)
        {
            return DeleteRelations(db) +
                   ClearReferences(db) +
                   db.Delete(this);
        }
        public int SaveRelation(Link e, DataAccess db)
        {
            return db.Insert(new ArtistLink(Id, e.Id));
        }
        public int DeleteRelations(DataAccess db)
        {
            return db.Delete(db.GetArtistLinks(this));
        }
        public int ClearReferences(DataAccess db)
        {
            var rows = 0;
            var books = db.GetBooksByArtist(Id);
            foreach (var book in books)
            {
                book.ArtistId = -1;
                rows += db.Update(book);
            }
            return rows;
        }
    }
}