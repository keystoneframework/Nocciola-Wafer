using Keystone.Carbonite;

namespace Nocciola.Wafer.Entities
{
    public class Gelato : StrongEntity<string>
    {
        public string Description { get; set; }
        public decimal PricePerGallon { get; set; }
    }
}