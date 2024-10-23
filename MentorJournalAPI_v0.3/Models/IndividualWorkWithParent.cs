using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class IndividualWorkWithParent
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Result { get; set; } = null!;

    public DateOnly Date { get; set; }

    public int ParentId { get; set; }

    public virtual Parent Parent { get; set; } = null!;
}
