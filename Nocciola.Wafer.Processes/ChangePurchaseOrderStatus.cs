using System;
using Keystone;
using Keystone.Carbonite.Diamant;
using Keystone.Clockwork;
using Keystone.Clockwork.To.Carbonite.Diamant.Sql;
using Nocciola.Wafer.Entities;

namespace Nocciola.Wafer.Processes
{
    public class ChangePurchaseOrderStatus : Mechanism<Null>
    {
        [Required]
        [NotEqualTo("00000000-0000-0000-0000-000000000000")]
        public Input<Guid> PurchaseOrderId;

        [Required]
        public Input<string> PurchaseOrderStatus;

        protected override Gear<Null> OnAssemble()
        {
            var getPurchaseOrder = new GetDetail<PurchaseOrder, PurchaseOrderDao, WaferCarboniteController>
            {
                Filter = new Where("Id = @Id", new WhereParameter("@Id", PurchaseOrderId.Value))
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