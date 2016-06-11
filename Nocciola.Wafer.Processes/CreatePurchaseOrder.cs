using Keystone;
using Keystone.Clockwork;
using Keystone.Clockwork.To.Carbonite.Diamant.Sql;
using Keystone.Mystere;
using Nocciola.Wafer.Entities;

namespace Nocciola.Wafer.Processes
{
    public class CreatePurchaseOrder : Mechanism<Null>
    {
        [Required]
        public Input<string> Restaurant;

        [Required]
        public Input<string> Gelato;

        [Required]
        public Input<int> Gallons;

        protected override Gear<Null> OnAssemble()
        {
            var mystere = MystereController.CreateWith<WaferInjectionRules>();

            var newPurchaseOrder = mystere.Build<NewPurchaseOrderProvider>();
            newPurchaseOrder.Restaurant = Restaurant;
            newPurchaseOrder.Gelato = Gelato;
            newPurchaseOrder.Gallons = Gallons;

            var setPurchaseOrderStatus = new SetPropertyOf<PurchaseOrder, string>
            {
                Object = newPurchaseOrder,
                PropertyName = "Status",
                NewValue = "Created"
            };

            var addPurchaseOrder = new AddDetail<PurchaseOrder, PurchaseOrderCreationValidations, PurchaseOrderDao, WaferCarboniteController>
            {
                Entity = setPurchaseOrderStatus
            };

            return addPurchaseOrder;
        }
    }
}