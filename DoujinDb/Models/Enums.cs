using System;
using System.Collections.Generic;
using System.Text;

namespace DoujinDb.Models
{
    public enum Language
    {
        Japanese,
        Romaji,
        English
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

    public enum OrderType
    {
        Direct,
        Forwarder,
        Proxy,
        Consolidation
    }

    public enum ProxyType
    {
        Proxy,
        Forwarder,
        Other
    }

    public enum StatusType
    {
        General,
        Scan,
        Order,
        Translation,
        Read
    }
}
