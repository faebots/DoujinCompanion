using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    class ArtistLink : Entity
    {
        [PrimaryKey, AutoIncrement]
        public override int Id { get; set; }
        [Indexed]
        public int ArtistId { get; set; }
        [Indexed]
        public int LinkId { get; set; }

        public ArtistLink() { }

        public ArtistLink(int Artist, int Link)
        {
            ArtistId = Artist;
            LinkId = Link;
        }
    }
}
