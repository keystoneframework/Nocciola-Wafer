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
            var almanac = AlmanacController.CreateWith<CompactPlainTextPersistence>();
            try
            {
                almanac.WriteInformation("Starting a new purchase order...");

                var newPurchaseOrder = OnGetNewPurchaseOrder();
                almanac.WriteInformation($"New purchase order ready: {newPurchaseOrder}");

                return newPurchaseOrder;
            }
            catch (Exception ex) { almanac.WriteError(ex, "New purchase order failure."); throw ex; }
        }

        protected abstract PurchaseOrder OnGetNewPurchaseOrder();
    }
}