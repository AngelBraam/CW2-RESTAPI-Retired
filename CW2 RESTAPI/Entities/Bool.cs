using System;
using System.Collections.Generic;

namespace CW2_RESTAPI.Entities;


public partial class Bool
{

    public Bool()
    {
        Location = new HashSet<Location>();
    }
    public int BoolId { get; set; }

    public bool? Units { get; set; }

    public bool? ActivityTimePreference { get; set; }

    public string? FkEmail { get; set; }

    public virtual Profile? FkEmailNavigation { get; set; } = null!;

    public virtual Profile Profile { get; set; } = null!;

    public virtual ICollection<Location> Location { get; set; }
}
