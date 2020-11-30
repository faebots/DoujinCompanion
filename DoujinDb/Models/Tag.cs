using System;
using System.Collections.Generic;
using System.Text;

namespace DoujinDb.Models
{
    public class Tag : Model
    {
        public override int? Id { get; set; }
        public string Name { get; set; }
        public bool IsWarning { get; set; }

        internal override Entities.Entity ToEntity()
        {
            var e = new Entities.Tag
            {
                Name = Name,
                IsWarning = IsWarning
            };
            if (Id.HasValue)
                e.Id = Id.Value;
            return e;
        }
    }
}
