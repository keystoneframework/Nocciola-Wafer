using System;
using Keystone.Carbonite.Persistence.Relational.Sql;

namespace Nocciola.Wafer.Entities.Persistence
{
    public class PurchaseOrderDao : ConventionFirstSqlDao<PurchaseOrder, Guid> { }
}