using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using DoujinDb.Entities;
using System.Linq;

namespace DoujinDb
{
    public class TestingInterface
    {
        internal DataAccess _db { get; set; }

        public readonly Dictionary<Models.LinkType, string> LinkTypeDict = new Dictionary<Models.LinkType, string>
        {
            { Models.LinkType.Other, "Other" },
            { Models.LinkType.Proxy, "Proxy" },
            { Models.LinkType.Share, "Share" },
            { Models.LinkType.SocialMedia, "SocialMedia" },
            { Models.LinkType.StoreFront, "StoreFront" },
            { Models.LinkType.StoreListing, "StoreListing" }
        };

        public TestingInterface(string path)
        {
            DataContext.Init(path);
            _db = DataContext._data;
            Console.WriteLine("Database initialized");
        }

        internal void Print(ArtistLink e)
        {
            Console.WriteLine($"Id: {e.Id}");
            Console.WriteLine($"ArtistId: {e.ArtistId}");
            Console.WriteLine($"LinkId: {e.LinkId}");
            var e1 = _db.GetArtists(e.ArtistId);
            if (e1 != null)
                Print(e1);
            var e2 = _db.GetLinks(e.LinkId);
            if (e2 != null)
                Print(e2);
        }

        internal void Print(Link e)
        {
            Console.WriteLine($"Id: {e.Id}");
            Console.WriteLine($"SiteName: {e.SiteName}");
            Console.WriteLine($"Type: {e.Type}");

        }

        internal void Print(Artist e)
        {
            Console.WriteLine($"Id: {e.Id}");
            Console.WriteLine($"Name: {e.Name}");
        }
        public void InsertArtist(string name)
        {
            var e = new Artist
            {
                Name = name
            };
            _db.Insert(e);
            Print(e);
        }
        public void GetArtist(int id)
        {
            var e = _db.GetArtists(id);
            Print(e);
        }
        public void GetAllArtists()
        {
            foreach (var a in _db.GetArtists())
                Print(a);
        }
        public void UpdateArtist(int id, string name)
        {
            var e = _db.GetArtists(id);
            Print(e);
            e.Name = name;
            _db.Update(e);
            Console.WriteLine("Updated:");
            Print(e);
        }
        public void DeleteArtist(int id)
        {
            var e = _db.GetArtists(id);
            Console.WriteLine("Deleting:");
            Print(e);
            var r = _db.Delete(e);
            Console.WriteLine($"Deleted rows: {r}");
            e = _db.GetArtists(id);
            if (e == null)
                Console.WriteLine($"Could not find {id} anymore");
        }


    }
}
