using Keystone;
using Keystone.Clockwork;
using Keystone.Clockwork.To.Carbonite.Diamant.Sql;
using Nocciola.Wafer.Entities;

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