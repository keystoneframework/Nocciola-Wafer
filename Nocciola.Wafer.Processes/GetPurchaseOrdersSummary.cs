using Keystone.Carbonite.Diamant;
using Keystone.Clockwork.To.Carbonite.Diamant.Sql;
using Nocciola.Wafer.Entities;

namespace Nocciola.Wafer.Processes
{
    public class GetPurchaseOrdersSummary : GetPagedMaster<PurchaseOrderSummary, PurchaseOrderSummaryDao, WaferCarboniteController>
    {
        public GetPurchaseOrdersSummary()
        {
            OrderingCriteria = new OrderBy("Created DESC");
        }
    }
}