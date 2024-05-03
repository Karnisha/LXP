using System;
using System.Collections.Generic;

namespace LXP.Data;

public partial class Material
{
    public Guid MaterialId { get; set; }

    public string Name { get; set; } = null!;

    public string Filepath { get; set; } = null!;

    public decimal Duration { get; set; }

    public Guid MaterialTypeId { get; set; }

    public bool IsActive { get; set; }

    public bool IsAvailable { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedAt { get; set; }

    public Guid TopicId { get; set; }

    public virtual Materialtype MaterialType { get; set; } = null!;

    public virtual Topic Topic { get; set; } = null!;

    public virtual ICollection<Userprogress> Userprogresses { get; set; } = new List<Userprogress>();
}
