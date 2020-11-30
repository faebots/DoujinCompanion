using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoujinDb;
using DoujinDb.Models;

namespace TestingConsole
{
    class Program
    {   /*
        static DataContext db;
        static List<Artist> Artists = new List<Artist>();
        static List<Book> Books = new List<Book>();
        static List<CollectionItem> Collection = new List<CollectionItem>();
        static List<WishlistItem> Wishlist = new List<WishlistItem>();

        static Dictionary<LinkType, string> LinkTypeDict = new Dictionary<LinkType, string>
        {
            { LinkType.Other, "Other" },
            { LinkType.Proxy, "Proxy" },
            { LinkType.Share, "Share" },
            { LinkType.SocialMedia, "SocialMedia" },
            { LinkType.StoreFront, "StoreFront" },
            { LinkType.StoreListing, "StoreListing" }
        };

        static Dictionary<Language, string> LanguageDict = new Dictionary<Language, string>
        {
            { Language.English, "English" },
            { Language.Japanese, "Japanese" },
            { Language.Romaji, "Romaji" }
        };

        const Language DefaultTitleLanguage = Language.Romaji;

        static void Main(string[] args)
        {
            db = new DataContext(@"C:\Testing");

            var book = new Book
            {
                Artist = new Artist
                {
                    Name = "sayasalt"
                },
                CoverFilePath = @"C:\Testing\Cover.jpg",
                Description = "Idk what this is about yet but it's sayasalt so it's gonna be devastating",
                Length = 200,
                Price = 3000,
                PurchaseLink = new Link
                {
                    SiteName = "Toranoana",
                    Type = LinkType.StoreListing,
                    Url = "http://www.toranoana.jp"
                },
                R18 = false,
                Type = new BookType
                {
                    Name = "Doujinshi",
                    Id = 1
                }
            };
            book.Title.Add(Language.English, "MESSIAH");

            book.Save(db);

            Books = db.GetBooks().ToList();

            foreach (var b in Books)
                Print(b);

            Console.ReadKey();
            /*
            string x = "";
            while (x != "Quit")
            {
                Console.WriteLine("TABLES:");
                Console.WriteLine("Artist");
                Console.WriteLine("Book");
                Console.WriteLine("Collection");
                x = Console.ReadLine();
                if (x == "Artist") ArtistStuff();
                if (x == "Book") BookStuff();
                if (x == "Collection") CollectionStuff();
            }
            */
        }


        //ARTISTS//
        static void ArtistStuff()
        {
            string x = "";
            while (x != "Return")
            {
                Console.WriteLine("List - Lookup - Add - Delete - Return");
                Console.ReadLine();
                if (x == "List") ListArtists();
            }
        }

        static int AddArtist()
        {
            return -1;
        }
        static void ListArtists()
        {
            foreach (var artist in db.Artists)
                Print(artist);
        }

        //BOOKS//
        static void BookStuff()
        {

        }
        static int AddBook()
        {
            return -1;
        }

        //COLLECTION//
        static void CollectionStuff()
        {
            
        }
        static int AddCollectionItem()
        {
            return -1;
        }
        static int AddLink()
        {
            return -1;
        }


        static void Print(Artist artist)
        {
            Console.WriteLine($"Id: {artist.Id}");
            Console.WriteLine($"Name: {artist.Name}");
            foreach (var link in artist.Links)
                Print(link);
            Console.WriteLine("Books:");
            foreach (var book in Books.Where(b => b.Artist.Equals(artist)))
            {
                Console.Write($"{book.Id} - ");
                if (book.Title.ContainsKey(DefaultTitleLanguage))
                    Console.Write(book.Title[DefaultTitleLanguage]);
                else
                    Console.Write(book.Title.Values.FirstOrDefault());
                Console.Write("\n");
            }
        }
        static void Print(Link link)
        {
            Console.WriteLine($"Id: {link.Id}");
            Console.WriteLine($"Type: {LinkTypeDict[link.Type]}");
            Console.WriteLine($"SiteName: {link.SiteName}");
            Console.WriteLine($"URL: {link.Url}");
        }
        static void Print(Book book)
        {
            Console.WriteLine($"Id: {book.Id}");
            foreach (var lang in book.Title.Keys)
                Console.WriteLine($"{LanguageDict[lang]} Title: {book.Title[lang]}");
            Console.WriteLine($"Cover: {book.CoverFilePath}");
            Console.WriteLine($"Description: {book.Description}");
            Console.WriteLine($"Length: {book.Length}");
            if (book.PurchaseLink != null)
            {
                Console.WriteLine("Purchase Link:");
                Print(book.PurchaseLink);
            }
            Console.WriteLine($"R18? {book.R18}");
            if (book.Type != null)
                Print(book.Type);
        }
        static void Print(BookType type)
        {
            Console.WriteLine($"Id: {type.Id}");
            Console.WriteLine($"Name: {type.Name}");
            Console.WriteLine($"Description: {type.Description}");
        }

    }
}
