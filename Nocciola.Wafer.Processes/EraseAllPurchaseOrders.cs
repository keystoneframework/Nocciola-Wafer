using Keystone;
using Keystone.Clockwork;
using Keystone.Clockwork.Bindings.Carbonite.Persistence.Relational.Sql;
using Nocciola.Wafer.Entities;
using Nocciola.Wafer.Entities.Persistence;

namespace Nocciola.Wafer.Processes
{
    public class EraseAllPurchaseOrders : Mechanism<Null>
    {
        protected override Gear<Null> OnAssemble()
        {
            var removePurchaseOrders = new RemoveAll<PurchaseOrder, PurchaseOrderDao> { WithCarbonite = new WaferCarboniteController() };

            return removePurchaseOrders;
        }
    }
}