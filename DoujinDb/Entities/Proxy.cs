using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    class Proxy : Entity
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Models.ProxyType Type { get; set; }

        public Models.Proxy ToModel()
        {
            return new Models.Proxy
            {
                Id = Id,
                Name = Name,
                Url = Url,
                Type = Type
            };
        }
    }
}
