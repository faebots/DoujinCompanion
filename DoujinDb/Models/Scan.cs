using System;
using System.Collections.Generic;
using System.Text;

namespace DoujinDb.Models
{
    public class Scan : Model
    {
        public override int? Id { get; set; }
        public string FilePath { get; set; }
        public Status Status { get; set; }
        public Link ScanShare { get; set; }
        public string ScannedBy { get; set; }
        public Language ScanLanguage { get; set; }

        internal override Entities.Entity ToEntity()
        {
            var e = new Entities.Scan
            {
                FilePath = FilePath,
                ScannedBy = ScannedBy,
                ScanLanguage = ScanLanguage
            };
            if (Id.HasValue)
                e.Id = Id.Value;
            if (Status != null && Status.Id.HasValue)
                e.Status = Status.Id.Value;
            if (ScanShare != null && ScanShare.Id.HasValue)
                e.ScanShareLinkId = ScanShare.Id.Value;
            return e;
        }
    }
}
