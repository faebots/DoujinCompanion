using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    class Artist
    {
        [PrimaryKey, AutoIncrement]
        int Id { get; set; }
        string Name { get; set; }
        
        Models.Artist ToModel()
        {
            return new Models.Artist
            {
                Id = Id,
                Name = Name
            };
        }

        Models.Artist ToModel(DataAccess db)
        {
            var model = this.ToModel();
            return model;
        }
    }
}