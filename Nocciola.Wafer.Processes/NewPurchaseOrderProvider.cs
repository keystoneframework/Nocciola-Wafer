using System;
using Keystone.Almanac;
using Keystone.Almanac.Persistence.PlainText;
using Keystone.Clockwork;
using Keystone.Clockwork.Validation.DeclarationFirst;
using Nocciola.Wafer.Entities;

namespace Nocciola.Wafer.Processes
{
    public abstract class NewPurchaseOrderProvider : Gear<PurchaseOrder>
    {
        [Required]
        public Input<string> Restaurant;

        [Required]
        public Input<string> Gelato;

        [Required]
        public Input<int> Gallons;

        protected override PurchaseOrder OnRun()
        {
            var almanac = AlmanacController.CreateWith<PlainTextPersistence>("Noccional.Wafer");
            try
            {
                almanac.WriteEntry(new Information("Starting a new purchase order..."));
                var newPurchaseOrder = OnGetNewPurchaseOrder();
                almanac.WriteEntry(new Information($"New purchase order ready: {newPurchaseOrder}"));

                return newPurchaseOrder;
            }
            catch (Exception ex) { almanac.WriteEntry(new Error("New purchase order failure.", ex)); throw ex; }
        }

        protected abstract PurchaseOrder OnGetNewPurchaseOrder();
    }
}