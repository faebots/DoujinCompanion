using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;

namespace DoujinDb.Entities
{
    class Order : Entity
    {
        [PrimaryKey, AutoIncrement]
        public override int Id { get; set; }
        [Indexed]
        public int StatusId { get; set; }
        public Models.OrderType Type { get; set; }
        [Indexed]
        public int ProxyId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        [Indexed]
        public int? ConsolidationOrderId { get; set; }

        public Models.Order ToModel()
        {
            return new Models.Order
            {
                Id = Id,
                Type = Type,
                OrderDate = OrderDate,
                ShipDate = ShipDate,
                DeliveryDate = DeliveryDate
            };
        }

        public Models.Order ToModel(DataAccess db)
        {
            var model = ToModel();
            model.Items = db.GetBooksByOrder(this).Select(b => b.ToModel(db)).ToList();
            model.OtherItems = db.GetOrderItems(this).Select(x => x.Item).ToList();
            model.Status = db.GetStatuses(StatusId).ToModel();
            model.Proxy = db.GetProxies(ProxyId).ToModel();
            if (!ConsolidationOrderId.HasValue)
                model.SubOrders = db.GetSubOrders(Id).Select(o => o.ToModel(db)).ToList();
            return model;
        }

        public Models.Order ToModelDeep(DataAccess db)
        {
            var model = ToModel(db);
            model.Items = db.GetBooksByOrder(this).Select(b => b.ToModelDeep(db)).ToList();
            if (!ConsolidationOrderId.HasValue)
                model.SubOrders = db.GetSubOrders(Id).Select(o => o.ToModelDeep(db)).ToList();
            return model;
        }
    }
}
