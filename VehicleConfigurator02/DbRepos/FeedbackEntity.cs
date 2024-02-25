using System;
using System.Collections.Generic;

namespace VehicleConfigurator02.DbRepos;

public partial class FeedbackEntity
{
    public int Id { get; set; }

    public string? Comments { get; set; }

    public string? Email { get; set; }

    public string? FeedbackType { get; set; }

    public string? Name { get; set; }
}
