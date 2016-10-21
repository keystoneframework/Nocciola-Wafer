using Keystone.Quantum;
using Keystone.Quantum.Json;
using Keystone.Carbonite.Diamant.Sql;


namespace Nocciola.Wafer.Entities
{
    public class WaferCarboniteController : SqlCarboniteController
    {
        public WaferCarboniteController() : base(QuantumController.CreateWith<JsonPersistence>()["WaferCarboniteController", "ConnectionString"]) { }
    }
}