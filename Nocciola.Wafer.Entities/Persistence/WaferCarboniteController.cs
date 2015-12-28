using Keystone.Carbonite.Persistence.Relational.Sql;

namespace Nocciola.Wafer.Entities.Persistence
{
    public class WaferCarboniteController : SqlCarboniteController
    {
        public WaferCarboniteController() : base("Data source=(local); Initial catalog=nocciola_wafer; Integrated security=SSPI") { }
    }
}