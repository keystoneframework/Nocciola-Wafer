using Keystone.Quantum;
using Keystone.Quantum.Persistence.Xml;
using Keystone.Carbonite.Persistence.Relational.Sql;

namespace Nocciola.Wafer.Entities.Persistence
{
    public class WaferCarboniteController : SqlCarboniteController
    {
        public WaferCarboniteController() : base(QuantumController.CreateWith<XmlPersistence>()["WaferCarboniteController", "ConnectionString"]) { }
    }
}