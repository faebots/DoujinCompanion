using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    class Vendor : Entity
    {
        [PrimaryKey, AutoIncrement]
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public Models.Vendor ToModel()
        {
            return new Models.Vendor
            {
                Id = Id,
                Name = Name,
                Url = Url
            };
        }
    }
}
