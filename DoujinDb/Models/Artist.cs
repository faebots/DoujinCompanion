using System;
using System.Collections.Generic;
using System.Text;

namespace DoujinDb.Models
{
    public class Artist
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<Link> Links { get; set; }
    }
}
