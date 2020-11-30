using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    class Title : Entity
    {
        [PrimaryKey, AutoIncrement]
        public override int Id { get; set; }
        [Indexed]
        public int BookId { get; set; }
        [Indexed]
        public Models.Language Language { get; set; }
        public string Name { get; set; }
    }
}