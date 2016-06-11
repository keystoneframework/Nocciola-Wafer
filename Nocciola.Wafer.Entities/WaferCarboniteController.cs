using Keystone.Quantum;
using Keystone.Quantum.Xml;
using Keystone.Carbonite.Diamant.Sql;

namespace Nocciola.Wafer.Entities
{
    public class WaferCarboniteController : SqlCarboniteController
    {
        public WaferCarboniteController() : base(QuantumController.CreateWith<XmlPersistence>()["WaferCarboniteController", "ConnectionString"]) { }
    }
}