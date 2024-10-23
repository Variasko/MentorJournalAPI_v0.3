using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class ParentConference
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public int AmountPresent { get; set; }

    public int AmountMiss { get; set; }

    public string Title { get; set; } = null!;

    public string Result { get; set; } = null!;

    public int GroupId { get; set; }

    public virtual Group Group { get; set; } = null!;
}
