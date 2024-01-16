using System;
using System.Collections.Generic;

namespace CW2_RESTAPI.Entities;

public partial class ProfileMicroService
{
    public string Email { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? AboutMe { get; set; }

    public int? Height { get; set; }

    public int? Weight { get; set; }

    public string? Birthday { get; set; }

    public string? MemberLocation { get; set; }

    public bool? Units { get; set; }

    public bool? ActivityTimePreference { get; set; }
}
