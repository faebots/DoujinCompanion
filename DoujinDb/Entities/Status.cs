using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    class Status : Entity
    {
        [PrimaryKey, AutoIncrement]
        public override int Id { get; set; }
        public string Name { get; set; }
        public Models.StatusType Type { get; set; }

        public Models.Status ToModel()
        {
            return new Models.Status
            {
                Id = Id,
                Name = Name,
                Type = Type
            };
        }
    }
}
