using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    public class Proxy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Models.ProxyType Type { get; set; }
    }
}
