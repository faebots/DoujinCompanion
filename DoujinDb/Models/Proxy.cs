using System;
using System.Collections.Generic;
using System.Text;

namespace DoujinDb.Models
{
    public class Proxy
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public ProxyType Type { get; set; }
    }

    public enum ProxyType
    {
        Proxy,
        Forwarder,
        Other
    }
}
