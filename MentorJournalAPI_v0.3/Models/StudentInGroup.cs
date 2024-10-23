using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class StudentInGroup
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int GroupId { get; set; }

    public DateOnly Date { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
