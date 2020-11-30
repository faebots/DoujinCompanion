using System;
using System.Collections.Generic;
using System.Text;

namespace DoujinDb.Models
{
    public class Status : Model
    {
        public override int? Id { get; set; }
        public string Name { get; set; }
        public StatusType Type { get; set; }

        internal override Entities.Entity ToEntity()
        {
            var e = new Entities.Status
            {
                Name = Name,
                Type = Type
            };
            if (Id.HasValue)
                e.Id = Id.Value;
            return e;
        }
    }
}
