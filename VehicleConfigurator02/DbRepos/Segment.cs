using System;
using System.Collections.Generic;

namespace VehicleConfigurator02.DbRepos;

public partial class Segment
{
    public int Id { get; set; }

    public string SegName { get; set; } = null!;

    public virtual ICollection<Manufacturer> Manufacturers { get; } = new List<Manufacturer>();

    public virtual ICollection<Model> Models { get; } = new List<Model>();
}
