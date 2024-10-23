using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class Mentor
{
    public int PersonId { get; set; }

    public int CategoryId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
