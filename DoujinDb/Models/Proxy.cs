﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DoujinDb.Models
{
    public class Proxy : Model
    {
        public override int? Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public ProxyType Type { get; set; }

        internal override Entities.Entity ToEntity ()
        {
            var e = new Entities.Proxy
            {
                Name = Name,
                Url = Url,
                Type = Type
            };
            if (Id.HasValue)
                e.Id = Id.Value;
            return e;
        }
    }
}
