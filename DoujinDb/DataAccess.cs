using System.Collections.Generic;
using System.Linq;
using SQLite;
using DoujinDb.Entities;

namespace DoujinDb
{
    class DataAccess
    {
        internal SQLiteConnection _db;
        internal bool IsInitialized;
        
        public DataAccess()
        {
            _db = null;
            IsInitialized = false;
        }

        public void LoadDb(string path)
        {
            _db = new SQLiteConnection(path);
            _db.CreateTable<Artist>();
            _db.CreateTable<ArtistLink>();
            _db.CreateTable<Book>();
            _db.CreateTable<BookTag>();
            _db.CreateTable<BookType>();
            _db.CreateTable<Collection>();
            _db.CreateTable<BookOrder>();
            _db.CreateTable<File>();
            _db.CreateTable<Link>();
            _db.CreateTable<Order>();
            _db.CreateTable<OrderItem>();
            _db.CreateTable<Proxy>();
            _db.CreateTable<Scan>();
            _db.CreateTable<Status>();
            _db.CreateTable<Tag>();
            _db.CreateTable<Title>();
            _db.CreateTable<Vendor>();
            IsInitialized = true;
        }

        //General query methods
        public int Insert(Entity entity)
        {
            return _db.Insert(entity);
        }
        public int Insert(IEnumerable<Entity> entities)
        {
            return entities.Aggregate(0, (i, e) => i += Insert(e));
        }
        public int Update(Entity entity)
        {
            return _db.Update(entity);
        }
        public int Update(IEnumerable<Entity> entities)
        {
            return entities.Aggregate(0, (i, e) => i += Update(e));
        }
        public int Delete(Entity entity)
        {
            return _db.Delete(entity);
        }
        public int Delete(IEnumerable<Entity> entities)
        {
            return entities.Aggregate(0, (i, e) => i += Delete(e));
        }

        //Artist query methods
        public IEnumerable<Artist> GetArtists()
        {
            return _db.Table<Artist>();
        }
        public IEnumerable<Artist> GetArtists(IEnumerable<int> ids)
        {
            return GetArtists().Where(a => ids.Contains(a.Id));
        }
        public Artist GetArtists(int id)
        {
            return GetArtists().SingleOrDefault(a => a.Id == id);
        }

        //ArtistLink query methods
        private IEnumerable<ArtistLink> GetArtistLinks()
        {
            return _db.Table<ArtistLink>();
        }
        public IEnumerable<ArtistLink> GetArtistLinks(Artist artist)
        {
            return GetArtistLinks().Where(al => al.ArtistId == artist.Id);
        }
        public IEnumerable<ArtistLink> GetArtistLinks(Link link)
        {
            return GetArtistLinks().Where(al => al.LinkId == link.Id);
        }
        public ArtistLink GetArtistLinks(int a, int l)
        {
            return GetArtistLinks().SingleOrDefault(al => al.ArtistId == a && al.LinkId == l);
        }

        //Book query methods
        public IEnumerable<Book> GetBooks()
        {
            return _db.Table<Book>();
        }
        public IEnumerable<Book> GetBooks(IEnumerable<int> ids)
        {
            return GetBooks().Where(b => ids.Contains(b.Id));
        }
        public Book GetBooks(int id)
        {
            return GetBooks().SingleOrDefault(b => b.Id == id);
        }
        public IEnumerable<Book> GetBooksByOrder(Order order)
        {
            return GetBooks(GetBookOrders(order));
        }
        public IEnumerable<Book> GetBooksByArtist(int id)
        {
            return GetBooks().Where(b => b.ArtistId == id);
        }

        //BookTag query methods
        private IEnumerable<BookTag> GetBookTags()
        {
            return _db.Table<BookTag>();
        }
        private IEnumerable<BookTag> GetBookTags(Book book)
        {
            return GetBookTags().Where(bt => bt.BookId == book.Id);
        }
        private IEnumerable<BookTag> GetBookTags(Tag tag)
        {
            return GetBookTags().Where(bt => bt.TagId == tag.Id);
        }

        //BookType query methods
        public IEnumerable<BookType> GetBookTypes()
        {
            return _db.Table<BookType>();
        }
        public IEnumerable<BookType> GetBookTypes(IEnumerable<int> ids)
        {
            return GetBookTypes().Where(bt => ids.Contains(bt.Id));
        }
        public BookType GetBookTypes(int id)
        {
            return GetBookTypes().SingleOrDefault(bt => bt.Id == id);
        }

        //Collection query methods
        public IEnumerable<Collection> GetCollections()
        {
            return _db.Table<Collection>();
        }
        public IEnumerable<Collection> GetCollections(IEnumerable<int> ids)
        {
            return GetCollections().Where(c => ids.Contains(c.Id));
        }
        public Collection GetCollections(int id)
        {
            return GetCollections().SingleOrDefault(c => c.Id == id);
        }

        //BookOrder query methods
        private IEnumerable<BookOrder> GetBookOrders()
        {
            return _db.Table<BookOrder>();
        }
        private IEnumerable<int> GetBookOrders(Book book)
        {
            return GetBookOrders().Where(d => d.BookId == book.Id).Select(d => d.OrderId);
        }
        private IEnumerable<int> GetBookOrders(Order order)
        {
            return GetBookOrders().Where(d => d.OrderId == order.Id).Select(d => d.BookId);
        }

        //File query methods
        public IEnumerable<File> GetFiles()
        {
            return _db.Table<File>();
        }
        public IEnumerable<File> GetFiles(IEnumerable<int> ids)
        {
            return GetFiles().Where(f => ids.Contains(f.Id));
        }
        public File GetFiles(int id)
        {
            return GetFiles().SingleOrDefault(f => f.Id == id);
        }

        //Link query methods
        public IEnumerable<Link> GetLinks()
        {
            return _db.Table<Link>();
        }
        public IEnumerable<Link> GetLinks(IEnumerable<int> ids)
        {
            return GetLinks().Where(l => ids.Contains(l.Id));
        }
        public Link GetLinks(int id)
        {
            return GetLinks().SingleOrDefault(l => l.Id == id);
        }
        public IEnumerable<Link> GetLinksByArtist(Artist artist)
        {
            return GetLinks(GetArtistLinks(artist).Select(x => x.LinkId));
        }

        //Order query methods
        public IEnumerable<Order> GetOrders()
        {
            return _db.Table<Order>();
        }
        public IEnumerable<Order> GetOrders(IEnumerable<int> ids)
        {
            return GetOrders().Where(o => ids.Contains(o.Id));
        }
        public Order GetOrders(int id)
        {
            return GetOrders().SingleOrDefault(o => o.Id == id);
        }
        public IEnumerable<Order> GetSubOrders(int id)
        {
            return GetOrders().Where(o => o.ConsolidationOrderId == id);
        }

        //OrderItem query methods
        private IEnumerable<OrderItem> GetOrderItems()
        {
            return _db.Table<OrderItem>();
        }
        public IEnumerable<OrderItem> GetOrderItems(Order order)
        {
            return GetOrderItems().Where(oi => oi.Id == order.Id);
        }

        //Proxy query methods
        public IEnumerable<Proxy> GetProxies()
        {
            return _db.Table<Proxy>();
        }
        public IEnumerable<Proxy> GetProxies(IEnumerable<int> ids)
        {
            return GetProxies().Where(p => ids.Contains(p.Id));
        }
        public Proxy GetProxies(int id)
        {
            return GetProxies().SingleOrDefault(p => p.Id == id);
        }

        //Scan query methods
        public IEnumerable<Scan> GetScans()
        {
            return _db.Table<Scan>();
        }
        public IEnumerable<Scan> GetScans(IEnumerable<int> ids)
        {
            return GetScans().Where(s => ids.Contains(s.Id));
        }
        public Scan GetScans(int id)
        {
            return GetScans().SingleOrDefault(s => s.Id == id);
        }
        public IEnumerable<Scan> GetScansByCollection(int id)
        {
            return GetScans().Where(s => s.BookId == id);
        }

        //Status query methods
        public IEnumerable<Status> GetStatuses()
        {
            return _db.Table<Status>();
        }
        public IEnumerable<Status> GetStatuses(IEnumerable<int> ids)
        {
            return GetStatuses().Where(s => ids.Contains(s.Id));
        }
        public Status GetStatuses(int id)
        {
            return GetStatuses().SingleOrDefault(s => s.Id == id);
        }

        //Tag query methods
        public IEnumerable<Tag> GetTags()
        {
            return _db.Table<Tag>();
        }
        public IEnumerable<Tag> GetTags(IEnumerable<int> ids)
        {
            return GetTags().Where(t => ids.Contains(t.Id));
        }
        public Tag GetTags(int id)
        {
            return GetTags().SingleOrDefault(t => t.Id == id);
        }
        public IEnumerable<Tag> GetTagsByBook(Book book)
        {
            return GetTags(GetBookTags(book).Select(bt => bt.TagId));
        }

        //Title query methods
        private IEnumerable<Title> GetTitles()
        {
            return _db.Table<Title>();
        }
        public IEnumerable<Title> GetTitles(Book book)
        {
            return GetTitles().Where(t => t.BookId == book.Id);
        }
        public Title GetTitles(Book book, Models.Language lang)
        {
            return GetTitles().SingleOrDefault(t => t.BookId == book.Id && t.Language == lang);
        }
 
        //Vendor query methods
        public IEnumerable<Vendor> GetVendors()
        {
            return _db.Table<Vendor>();
        }
        public IEnumerable<Vendor> GetVendors(IEnumerable<int> ids)
        {
            return GetVendors().Where(v => ids.Contains(v.Id));
        }
        public Vendor GetVendors(int id)
        {
            return GetVendors().SingleOrDefault(v => v.Id == id);
        }
    }
}
