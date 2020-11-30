using System;
using System.Collections.Generic;
using System.Text;

namespace DoujinDb.Models
{
    public class BookType : Model
    {
        public override int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        internal override Entities.Entity ToEntity()
        {
            var e = new Entities.BookType
            {
                Name = Name,
                Description = Description
            };
            if (Id.HasValue)
                e.Id = Id.Value;
            return e;
        }
    }
}
