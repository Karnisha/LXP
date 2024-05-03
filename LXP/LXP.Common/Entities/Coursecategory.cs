using System;
using System.Collections.Generic;

namespace LXP.Data;

public partial class Coursecategory
{
    public Guid CatagoryId { get; set; }

    public string Category { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedAt { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
