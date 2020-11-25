using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb
{
    internal class DataAccess
    {
        readonly SQLiteConnection _database;

        public DataAccess(string path)
        {
            _database = new SQLiteConnection(path);
            _database.CreateTable<Entities.Artist>();
            _database.CreateTable<Entities.Collection>();
            _database.CreateTable<Entities.DoujinOrder>();
            _database.CreateTable<Entities.Doujinshi>();
            _database.CreateTable<Entities.File>();
            _database.CreateTable<Entities.Order>();
            _database.CreateTable<Entities.OrderItem>();
            _database.CreateTable<Entities.Proxy>();
            _database.CreateTable<Entities.Status>();
            _database.CreateTable<Entities.Title>();
        }
    }
}
