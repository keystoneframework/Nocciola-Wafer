using System;
using Keystone.Carbonite.Diamant;
using Keystone.Clockwork.To.Carbonite.Diamant.Sql;
using Nocciola.Wafer.Entities;

namespace Nocciola.Wafer.Processes
{
    public class NewPurchaseOrder : NewPurchaseOrderProvider
    {
        protected override PurchaseOrder OnGetNewPurchaseOrder()
        {
            var restaurant = new GetDetail<Restaurant, RestaurantDao, WaferCarboniteController> { Filter = new Where("Id = @Id", new WhereParameter("@Id", Restaurant.Value)) }.Run();
            var gelato = new GetDetail<Gelato, GelatoDao, WaferCarboniteController> { Filter = new Where("Id = @Id", new WhereParameter("@Id", Gelato.Value)) }.Run();

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