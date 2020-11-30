using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    class Tag : Entity
    {
        [PrimaryKey, AutoIncrement]
        public override int Id { get; set; }
        public string Name { get; set; }
        public bool IsWarning { get; set; }

        public Models.Tag ToModel()
        {
            return new Models.Tag
            {
                Id = Id,
                Name = Name,
                IsWarning = IsWarning
            };
        }
    }
}
