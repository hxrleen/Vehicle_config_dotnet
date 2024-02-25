using System;
using System.Collections.Generic;

namespace VehicleConfigurator02.DbRepos;

public partial class Model
{
    public int Id { get; set; }

    public string? ImagePath { get; set; }

    public string? ModelName { get; set; }

    public double Price { get; set; }

    public long? MfgId { get; set; }

    public int? SegId { get; set; }

    public virtual Manufacturer? Mfg { get; set; }

    public virtual Segment? Seg { get; set; }

    public virtual ICollection<VehicleDetail> VehicleDetails { get; } = new List<VehicleDetail>();
}
