using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DoujinDb.Models
{
    public class Artist : Model
    {
        public Artist()
        {
            Links = new List<Link>();
        }

        public override int? Id { get; set; }
        public string Name { get; set; }
        public List<Link> Links { get; set; }

        internal override Entities.Entity ToEntity()
        {
            var e = new Entities.Artist
            {
                Name = Name
            };
            if (Id.HasValue)
                e.Id = Id.Value;
            return e;
        }

        internal override int Save(DataAccess db)
        {
            var rows = 0;
            var e = this.ToEntity();
            if (Id.HasValue)
                rows += db.Update(e);
            else
                rows += db.Insert(e);
            Id = e.Id;
            rows += Links.Aggregate(rows, (i, l) => i += SaveRelation(l, db));

            return rows;
        }

        private int SaveRelation(Link link, DataAccess db)
        {
            var newRelation = !link.Id.HasValue;
            var rows = link.Save(db);
            if (newRelation)
                rows += db.Insert(new Entities.ArtistLink { 
                    ArtistId = Id.Value,
                    LinkId = link.Id.Value 
                });
            return rows;
        }

        internal override int Delete(DataAccess db)
        {
            if (!Id.HasValue)
                return 0;
            var rows = 0;
            foreach (var link in Links)
                rows += link.Delete(db);
            rows += db.Delete(this.ToEntity());
            return rows;
        }

        public override bool Equals(object obj)
        {
            if (obj is Artist && Id.HasValue)
            {
                var a = obj as Artist;
                return (Id == a.Id);
            }
            else if (obj is Entities.Artist && Id.HasValue)
            {
                var a = obj as Entities.Artist;
                return (a.Id == Id.Value);
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
