using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class ObservationList
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public string Characteristic { get; set; } = null!;

    public DateOnly Date { get; set; }

    public virtual Student Student { get; set; } = null!;
}
