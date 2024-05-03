using System;
using System.Collections.Generic;

namespace LXP.Data;

public partial class Topic
{
    public Guid TopicId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedAt { get; set; }

    public Guid CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual ICollection<Userprogress> Userprogresses { get; set; } = new List<Userprogress>();
}
