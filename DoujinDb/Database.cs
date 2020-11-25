using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb
{
    public class Database
    {
        private DataAccess _data;

        public Database(string path)
        {
            _data = new DataAccess(path);
        }
    }
}
