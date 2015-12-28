using System;
using Keystone;
using Keystone.Carbonite.Persistence.Relational;
using Keystone.Clockwork;
using Keystone.Clockwork.Activation;
using Keystone.Clockwork.Bindings.Carbonite.Persistence.Relational.Sql;
using Nocciola.Wafer.Entities;
using Nocciola.Wafer.Entities.Persistence;

namespace Nocciola.Wafer.Processes
{
    public class ChangePurchaseOrderStatus : Mechanism<Null>
    {
        public Input<Guid> PurchaseOrderId;
        public Input<string> PurchaseOrderStatus;

        protected override Gear<Null> OnAssemble()
        {
            var getPurchaseOrder = new GetDetailBy<PurchaseOrder, PurchaseOrderDao, WaferCarboniteController>
            {
                FilteringCriteria = new Where("Id = @Id", new PredicateParameter("@Id", PurchaseOrderId.Value))
            };

            var setPurchaseOrderStatus = new SetPropertyOf<PurchaseOrder, string>
            {
                Object = getPurchaseOrder,
                PropertyName = "Status",
                NewValue = PurchaseOrderStatus
            };

            var updatePurchaseOrder = new UpdateDetail<PurchaseOrder, PurchaseOrderChangeValidations, PurchaseOrderDao, WaferCarboniteController>
            {
                Entity = setPurchaseOrderStatus
            };

            return updatePurchaseOrder;
        }
    }
}
