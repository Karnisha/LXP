﻿using System;
using System.Collections.Generic;

namespace LXP.Data;

public partial class Materialtype
{
    public Guid MaterialTypeId { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
