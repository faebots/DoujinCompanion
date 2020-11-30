using System;
using System.Collections.Generic;
using System.Text;

namespace DoujinDb.Models
{
    public class Link : Model
    {
        public override int? Id { get; set; }
        public string SiteName { get; set; }
        public string Url { get; set; }
        public LinkType Type { get; set; }

        internal override Entities.Entity ToEntity()
        {
            var e = new Entities.Link
            {
                SiteName = SiteName,
                Url = Url,
                Type = Type
            };
            if (Id.HasValue)
                e.Id = Id.Value;
            return e;
        }
    }
}
