using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    class Status
    {
        [PrimaryKey]
        string StatusCode { get; set; }
        string Name { get; set; }
        Models.StatusType Type { get; set; }
    }
}
