using System;
using System.Collections.Generic;

namespace LXP.Data;

public partial class Course
{
    public Guid CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Duration { get; set; }

    public string Thumbnail { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsAvailable { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedAt { get; set; }

    public Guid LevelId { get; set; }

    public Guid CatagoryId { get; set; }

    public virtual Coursecategory Catagory { get; set; } = null!;

    public virtual Courselevel Level { get; set; } = null!;

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();

    public virtual ICollection<Userprogress> Userprogresses { get; set; } = new List<Userprogress>();
}
