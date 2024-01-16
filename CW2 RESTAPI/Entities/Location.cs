using System;
using System.Collections.Generic;

namespace CW2_RESTAPI.Entities;

public partial class Location
{

    public int LocationId { get; set; }

    public string? MemberLocation { get; set; }

    public int? FkBoolId { get; set; }

    public Bool? Bool { get; set; }

    public virtual Bool? FkBool { get; set; }
}
