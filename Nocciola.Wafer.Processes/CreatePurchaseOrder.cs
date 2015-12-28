using Keystone;
using Keystone.Clockwork;
using Keystone.Clockwork.Activation;
using Keystone.Clockwork.Validation.DeclarationFirst;
using Keystone.Clockwork.Bindings.Carbonite.Persistence.Relational.Sql;
using Nocciola.Wafer.Entities;
using Nocciola.Wafer.Entities.Persistence;

namespace Nocciola.Wafer.Processes
{
    public class CreatePurchaseOrder : Mechanism<Null>
    {
        [Required]
        public Input<string> Restaurant;

        [Required]
        public Input<string> Gelato;

        [Required]
        [GreaterOrEqualTo(CompareWith = 1)]
        public Input<int> Gallons;

        protected override Gear<Null> OnAssemble()
        {
            var newPurchaseOrder = new NewPurchaseOrder 
            {
                Restaurant = Restaurant,
                Gelato = Gelato,
                Gallons = Gallons
            };

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
