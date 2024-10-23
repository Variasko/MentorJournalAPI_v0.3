using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class Activist
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int ActivityTypeId { get; set; }

    public virtual ActivityType ActivityType { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
