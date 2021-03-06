﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    class File : Entity
    {
        [PrimaryKey, AutoIncrement]
        public override int Id { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }

        public Models.StoredFile ToModel()
        {
            return new Models.StoredFile
            {
                Id = Id,
                FilePath = FilePath,
                FileType = FileType
            };
        }
    }
}
