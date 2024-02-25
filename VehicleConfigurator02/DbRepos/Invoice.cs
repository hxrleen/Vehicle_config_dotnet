using System;
using System.Collections.Generic;

namespace VehicleConfigurator02.DbRepos;

public partial class Invoice
{
    public int InvId { get; set; }

    public DateTime? InvDate { get; set; }

    public int ModelId { get; set; }
}
