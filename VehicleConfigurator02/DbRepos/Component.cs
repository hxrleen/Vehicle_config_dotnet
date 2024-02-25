using System;
using System.Collections.Generic;

namespace VehicleConfigurator02.DbRepos;

public partial class Component
{
    public int CompId { get; set; }

    public string? CompName { get; set; }

    public string? SubType { get; set; }

    public virtual ICollection<VehicleDetail> VehicleDetails { get; } = new List<VehicleDetail>();
}
