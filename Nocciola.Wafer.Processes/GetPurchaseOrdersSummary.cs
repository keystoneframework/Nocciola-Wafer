using Keystone.Clockwork.Bindings.Carbonite.Persistence.Relational.Sql;
using Keystone.Carbonite.Persistence.Relational;
using Nocciola.Wafer.Entities;
using Nocciola.Wafer.Entities.Persistence;

namespace Nocciola.Wafer.Processes
{
    public class GetPurchaseOrdersSummary : GetPagedMaster<PurchaseOrderSummary, PurchaseOrderSummaryDao, WaferCarboniteController>
    {
        public GetPurchaseOrdersSummary() { OrderingCriteria = new OrderBy("Created DESC"); }
    }
}