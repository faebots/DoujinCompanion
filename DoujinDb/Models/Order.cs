using System;
using System.Collections.Generic;
using System.Text;

namespace DoujinDb.Models
{
    public class Order
    {
        public int? Id { get; set; }
        public List<Doujinshi> Items { get; set; }
        public List<string> OtherItems { get; set; }
        public Status Status { get; set; }
        public OrderType Type { get; set; }
        public Proxy Proxy { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public List<Order> SubOrders { get; set; }
    }
    public enum OrderType
    {
        Direct,
        Forwarder,
        Proxy,
        Consolidation
    }
}
