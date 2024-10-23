using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class ClassHour
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public virtual ICollection<AttendClassHour> AttendClassHours { get; set; } = new List<AttendClassHour>();
}
