using System;
using Keystone.Carbonite;

namespace Nocciola.Wafer.Entities
{
    public class PurchaseOrderSummary : StrongEntity<Guid>
    {
        public string RestaurantName { get; set; }
        public string GelatoName { get; set; }
        public decimal Amount { get; set; }
        public string CurrentStatus { get; set; }
    }
}