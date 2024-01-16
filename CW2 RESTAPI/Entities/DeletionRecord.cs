using System;
using System.Collections.Generic;

namespace CW2_RESTAPI.Entities;

public partial class DeletionRecord
{
    public int DeletionId { get; set; }

    public string Operation { get; set; } = null!;

    public DateOnly DeletionDate { get; set; }
}
