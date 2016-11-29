using Keystone.Carbonite.Diamant;
using Keystone.Clockwork.To.Carbonite.Diamant.Sql;
using Nocciola.Wafer.Entities;

namespace Nocciola.Wafer.Processes
{
    public class GetPurchaseOrdersSummary : GetMaster<PurchaseOrderSummary, PurchaseOrderSummaryDao, WaferCarboniteController>
    {
        public GetPurchaseOrdersSummary()
        {
            Order = new OrderBy("Created DESC");
        }
    }
}