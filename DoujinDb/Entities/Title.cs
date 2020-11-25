using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    class Title
    {
        [Indexed]
        int DoujinId { get; set; }
        [Indexed]
        Models.Language Language { get; set; } //Doujinshi.Title key
        string Name { get; set; } //Doujinshi.Title value
    }
}
