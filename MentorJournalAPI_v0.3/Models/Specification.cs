using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class Specification
{
    public int Id { get; set; }

    public string Direction { get; set; } = null!;

    public string? Specialization { get; set; }

    public string ReductionDirection { get; set; } = null!;

    public string? ReductionSpecialization { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
