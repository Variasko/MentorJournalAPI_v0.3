using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class IndividualWordWithStudent
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Result { get; set; } = null!;

    public DateOnly Date { get; set; }

    public int StudentId { get; set; }

    public virtual Student Student { get; set; } = null!;
}
