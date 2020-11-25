using System;
using System.Collections.Generic;
using System.Text;

namespace DoujinDb.Models
{
    public class Link
    {
        public int? Id { get; set; }
        public string SiteName { get; set; }
        public string Url { get; set; }
        public LinkType Type { get; set; }
    }

    public enum LinkType
    {
        SocialMedia,
        StoreFront,
        StoreListing,
        Share,
        Proxy,
        Other
    }

}
