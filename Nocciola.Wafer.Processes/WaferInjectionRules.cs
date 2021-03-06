﻿using Keystone.Mystere;

namespace Nocciola.Wafer.Processes
{
    public class WaferInjectionRules : ConfigurationFirstInjectionStrategy
    {
        protected override BuildRules OnGetBuildRules()
            => BuildRules.CreateAsFollows(
                    ToBuild<NewPurchaseOrderProvider>(Do: () => new NewPurchaseOrder()));
    }
}