using Keystone.Carbonite;

namespace Nocciola.Wafer.Entities
{
    public class Restaurant : StrongEntity<string>
    {
        public string Address { get; set; }
    }
}
