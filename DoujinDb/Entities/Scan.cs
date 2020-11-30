using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    class Scan : Entity
    {
        [PrimaryKey,AutoIncrement]
        public override int Id { get; set; }
        public string FilePath { get; set; }
        [Indexed]
        public int CollectionId { get; set; }
        [Indexed]
        public int ScanShareLinkId { get; set; }
        [Indexed]
        public int Status { get; set; }
        public string ScannedBy { get; set; }
        public Models.Language ScanLanguage { get; set; }
        public int BookId { get; set; }

        public Models.Scan ToModel()
        {
            return new Models.Scan
            {
                Id = Id,
                FilePath = FilePath,
                ScannedBy = ScannedBy,
                ScanLanguage = ScanLanguage
            };
        }

        public Models.Scan ToModel(DataAccess db)
        {
            var model = ToModel();
            model.ScanShare = db.GetLinks(ScanShareLinkId).ToModel();
            model.Status = db.GetStatuses(Status).ToModel();
            return model;
        }
    }
}
