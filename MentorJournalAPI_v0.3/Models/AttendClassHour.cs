using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class AttendClassHour
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int ClassHourId { get; set; }

    public bool IsVisited { get; set; }

    public virtual ClassHour ClassHour { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
