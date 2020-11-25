using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DoujinDb.Entities
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int StatusId { get; set; }
        public Models.OrderType Type { get; set; }
        [Indexed]
        public int ProxyId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        [Indexed]
        public int ConsolidationOrderId { get; set; }
    }
}
