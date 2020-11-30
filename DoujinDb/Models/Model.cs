using System;
using System.Collections.Generic;
using System.Text;

namespace DoujinDb.Models
{
    public abstract class Model
    {
        public abstract int? Id { get; set; }

        internal abstract Entities.Entity ToEntity();
                
        public virtual int Save()
        {
            return this.Save(DataContext._data);
        }
        internal virtual int Save(DataAccess db)
        {
            var e = this.ToEntity();
            if (Id.HasValue)
                return db.Update(e);
            var rows = db.Insert(e);
            Id = e.Id;
            return rows;
        }

        public virtual int Delete()
        {
            return this.Delete(DataContext._data);
        }

        internal virtual int Delete(DataAccess db)
        {
            if (Id.HasValue)
                return db.Delete(this.ToEntity());
            else
                return 0;
        }
    }
}
