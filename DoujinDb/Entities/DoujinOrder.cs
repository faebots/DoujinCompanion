using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    public class DoujinOrder
    {
        [Indexed]
        public int DoujinId { get; set; }
        [Indexed]
        public int OrderId { get; set; }
    }
}
