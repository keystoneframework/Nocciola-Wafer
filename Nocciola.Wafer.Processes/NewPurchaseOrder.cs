using System;
using Keystone.Carbonite.Persistence.Relational;
using Keystone.Clockwork.Bindings.Carbonite.Persistence.Relational.Sql;
using Nocciola.Wafer.Entities;
using Nocciola.Wafer.Entities.Persistence;

namespace Nocciola.Wafer.Processes
{
    public class NewPurchaseOrder : NewPurchaseOrderProvider
    {
        protected override PurchaseOrder OnGetNewPurchaseOrder()
        {
            var restaurant = new GetDetailBy<Restaurant, RestaurantDao, WaferCarboniteController> { FilteringCriteria = new Where("Id = @Id", new PredicateParameter("@Id", Restaurant.Value)) }.Run();
            var gelato = new GetDetailBy<Gelato, GelatoDao, WaferCarboniteController> { FilteringCriteria = new Where("Id = @Id", new PredicateParameter("@Id", Gelato.Value)) }.Run();

            return new PurchaseOrder
            {
                Id = Guid.NewGuid(),
                RestaurantId = restaurant.Id,
                GelatoId = gelato.Id,
                Created = DateTime.Now,
                Gallons = Gallons.Value,
                ShippingAddress = restaurant.Address,
                TotalPrice = Gallons.Value * gelato.PricePerGallon
            };
        }
    }
}