using System;
using Keystone.Clockwork;

namespace Nocciola.Wafer.Processes
{
    public class PurchaseOrderCreationValidations
    {
        [Required]
        [NotEqualTo(CompareWith = "00000000-0000-0000-0000-000000000000")]
        public Guid Id { get; set; }

        [Required]
        public string RestaurantId { get; set; }

        [Required]
        public string GelatoId { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        [GreaterOrEqualTo(CompareWith = 0)]
        public int Gallons { get; set; }

        [Required]
        [GreaterOrEqualTo(CompareWith = "0")]
        public decimal TotalPrice { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        [Optional(DefaultsTo = "Created")]
        [EqualTo(CompareWith = "Created")]
        public string Status { get; set; }
    }
}