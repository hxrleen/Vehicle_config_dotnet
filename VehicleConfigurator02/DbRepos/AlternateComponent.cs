using System;
using System.Collections.Generic;

namespace VehicleConfigurator02.DbRepos;

public partial class AlternateComponent
{
    public int AltId { get; set; }

    public int AltCompId { get; set; }

    public int CompId { get; set; }

    public double DeltaPrice { get; set; }

    public int ModelId { get; set; }
}
