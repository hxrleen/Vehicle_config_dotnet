using System;
using System.Collections.Generic;

namespace VehicleConfigurator02.DbRepos;

public partial class VehicleDetail
{
    public int ConfigId { get; set; }

    public string? CompType { get; set; }

    public string? IsConfigurable { get; set; }

    public int? CompId { get; set; }

    public int? ModelId { get; set; }

    public virtual Component? Comp { get; set; }

    public virtual Model? Model { get; set; }
}
