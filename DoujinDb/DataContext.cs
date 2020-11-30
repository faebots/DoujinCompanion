using DoujinDb.Models;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace DoujinDb
{
    public static class DataContext
    {
        internal static readonly DataAccess _data = new DataAccess();
        public static string FilePath { get; set; }
        public static List<Artist> Artists { get; set; }
        public static List<Book> Books { get; set; }
        public static List<BookType> BookTypes { get; set; }
        public static List<CollectionItem> CollectionItems { get; set; }
        public static List<Order> Orders { get; set; }
        public static List<Proxy> Proxies { get; set; }
        public static List<Scan> Scans { get; set; }
        public static List<Status> Statuses { get; set; }
        public static List<Tag> Tags { get; set; }
        public static List<Vendor> Vendors { get; set; }
        public static List<WishlistItem> WishlistItems { get; set; }
        
        public static int Init(string path)
        {
            FilePath = path;
            var dbPath = GetDatabaseFilename(path);
            _data.LoadDb(path);

            if (_data._db == null || !_data.IsInitialized)
                return -1;

            LoadArtists();
            LoadBooks();
            LoadBookTypes();
            LoadOrders();
            LoadProxies();
            LoadScans();
            LoadTags();
            LoadVendors();

            return 0;
        }

        public static void LoadArtists()
        {
            Artists = _data.GetArtists().Select(a => a.ToModel(_data)).ToList();
        }
        public static void LoadBooks()
        {
            Books = _data.GetBooks().Select(b => b.ToModelDeep(_data)).ToList();
        }
        public static void LoadBookTypes()
        {
            BookTypes = _data.GetBookTypes().Select(bt => bt.ToModel()).ToList();
        }
        public static void LoadCollectionTypes()
        {
            CollectionItems = _data.GetCollections().Select(c => c.ToModelDeep(_data)).ToList();
        }
        public static void LoadOrders()
        {
            Orders = _data.GetOrders().Select(o => o.ToModelDeep(_data)).ToList();
        }
        public static void LoadProxies()
        {
            Proxies = _data.GetProxies().Select(p => p.ToModel()).ToList();
        }
        public static void LoadScans()
        {
            Scans = _data.GetScans().Select(s => s.ToModel(_data)).ToList();
        }
        public static void LoadTags()
        {
            Tags = _data.GetTags().Select(t => t.ToModel()).ToList();
        }
        public static void LoadVendors()
        {
            Vendors = _data.GetVendors().Select(v => v.ToModel()).ToList();
        }

        private static string GetDatabaseFilename(string path)
        {
            var files = Directory.EnumerateFiles(path, "*.db");
            if (files.Any())
            {
                var db = files.SingleOrDefault();
                if (db is null)
                {
                    db = files.SingleOrDefault(x => x == "data.db");
                    if (db is null)
                        throw new FileNotFoundException("Database file not found.");
                    else
                        return db;
                }
                else
                    return db;
            }
            else
                return Path.Combine(path, "data.db");
            
        }
    }
}
