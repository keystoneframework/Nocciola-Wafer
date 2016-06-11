using Keystone.Carbonite.Diamant;
using Keystone.Carbonite.Diamant.Sql;

namespace Nocciola.Wafer.Entities
{
    public class PurchaseOrderSummaryDao : ConfigurationFirstSqlDao<PurchaseOrderSummary>
    {
        protected override TableMappings OnGetMappings()
            => TableMappings.ForTable("purchase_order").Map(
                Column(Name: "id", With: entity => entity.Id, IsPrimaryKey: true),
                Column(Name: "restaurant_id", With: entity => entity.RestaurantName),
                Column(Name: "gelato_id", With: entity => entity.GelatoName),
                Column(Name: "total_price", With: entity => entity.Amount),
                Column(Name: "status", With: entity => entity.CurrentStatus));
    }
}