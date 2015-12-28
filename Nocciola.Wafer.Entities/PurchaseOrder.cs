using System;
using Keystone.Carbonite;

namespace Nocciola.Wafer.Entities
{
    public class PurchaseOrder : StrongEntity<Guid>
    {
        public string RestaurantId { get; set; }
        public string GelatoId { get; set; }
        public DateTime Created { get; set; }
        public int Gallons { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShippingAddress { get; set; }
        public string Status { get; set; }
    }
}
