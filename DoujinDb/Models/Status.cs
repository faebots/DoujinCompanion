using System;
using System.Collections.Generic;
using System.Text;

namespace DoujinDb.Models
{
    public class Status
    {
        public string StatusCode { get; set; }
        public string Name { get; set; }
        public StatusType Type { get; set; }
    }

    public enum StatusType
    {
        General,
        Scan,
        Order,
        Translation,
        Read
    }
}
