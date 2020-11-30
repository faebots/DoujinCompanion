using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DoujinDb.Models
{
    public class Order : Model
    {
        public Order()
        {
            Items = new List<Book>();
            OtherItems = new List<string>();
            SubOrders = new List<Order>();
        }

        public override int? Id { get; set; }
        public List<Book> Items { get; set; }
        public List<string> OtherItems { get; set; }
        public Status Status { get; set; }
        public OrderType Type { get; set; }
        public Proxy Proxy { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public List<Order> SubOrders { get; set; }

        internal override Entities.Entity ToEntity()
        {
            var e = new Entities.Order
            {
                Type = Type,
                OrderDate = OrderDate,
                ShipDate = ShipDate,
                DeliveryDate = DeliveryDate
            };
            if (Id.HasValue)
                e.Id = Id.Value;
            if (Status != null && Status.Id.HasValue)
                e.StatusId = Status.Id.Value;
            if (Proxy != null && Proxy.Id.HasValue)
                e.ProxyId = Proxy.Id.Value;
            return e;
        }

        internal override int Save(DataAccess db)
        {
            var rows = 0;
            var e = this.ToEntity() as Entities.Order;
            if (!Id.HasValue)
            {
                db.Insert(e);
                Id = e.Id;
            }

            var parent = GetParentOrder(db);
            if (parent != null)
            {
                parent.Save(db);
                e.ConsolidationOrderId = parent.Id.Value;
            }

            if (Status != null)
            {
                Status.Save(db);
                e.StatusId = Status.Id.Value;
            }
            if (Proxy != null)
            {
                Proxy.Save(db);
                e.ProxyId = Proxy.Id.Value;
            }

            rows += Items.Aggregate(rows, (i, x) => i += SaveRelations(x, db));
            
            var itemEntities = db.GetOrderItems(e);
            var newItems = OtherItems.Where(x => itemEntities.All(y => y.Item != x));
            var deletedItems = itemEntities.Where(y => OtherItems.All(x => x != y.Item));

            rows += newItems.Aggregate(rows, (i, x) => SaveOrderItem(x, db));
            rows += deletedItems.Aggregate(rows, (i, x) => DeleteOrderItem(x, db));

            return rows;    
        }

        public Order GetParentOrder()
        {
            return GetParentOrder(DataContext._data);
        }

        private Order GetParentOrder(DataAccess db)
        {
            var e = db.GetOrders(Id.Value);
            if (e.ConsolidationOrderId.HasValue)
            {
                var p = db.GetOrders(e.ConsolidationOrderId.Value);
                return p.ToModel();
            }
            else
                return null;
        }

        private int SaveRelations(Book book, DataAccess db)
        {
            if (!book.Id.HasValue)
                book.Save(db);
            else {
                var rel = db.GetBooksByOrder(this.ToEntity() as Entities.Order);
                if (rel.Any(r => r.Id == book.Id.Value))
                    return 0;
            }
                
            var e = new Entities.BookOrder
            {
                BookId = book.Id.Value,
                OrderId = Id.Value
            };
            return db.Insert(e);
        }

        private int SaveOrderItem (string item, DataAccess db)
        {
            var e = new Entities.OrderItem
            {
                OrderId = Id.Value,
                Item = item
            };
            return db.Insert(e);
        }

        private int DeleteOrderItem (Entities.OrderItem item, DataAccess db)
        {
            return db.Delete(item);
        }
    }
}
