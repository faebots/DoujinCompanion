using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    class Link : Entity
    {
        [PrimaryKey, AutoIncrement]
        public override int Id { get; set; }
        public string SiteName { get; set; }
        [MaxLength(255)]
        public string Url { get; set; }
        public Models.LinkType Type { get; set; }
        
        public Models.Link ToModel()
        {
            return new Models.Link
            {
                Id = Id,
                SiteName = SiteName,
                Url = Url,
                Type = Type
            };
        }
    }
}