using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    class BookTag : Entity
    {
        [PrimaryKey, AutoIncrement]
        public override int Id { get; set; }
        [Indexed]
        public int BookId { get; set; }
        [Indexed]
        public int TagId { get; set; }
    }
}
