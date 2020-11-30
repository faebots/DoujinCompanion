using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    class BookType : Entity
    {
        [PrimaryKey, AutoIncrement]
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Models.BookType ToModel()
        {
            return new Models.BookType
            {
                Id = Id,
                Name = Name,
                Description = Description
            };
        }
    }
}
