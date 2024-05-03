using System;
using System.Collections.Generic;

namespace LXP.Data;

public partial class Userprogress
{
    public Guid UserProgressId { get; set; }

    public TimeOnly WatchTime { get; set; }

    public TimeOnly TotalTime { get; set; }

    public bool IsWatched { get; set; }

    public Guid CourseId { get; set; }

    public Guid TopicId { get; set; }

    public Guid MaterialId { get; set; }

    public Guid UserId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Material Material { get; set; } = null!;

    public virtual Topic Topic { get; set; } = null!;
}
