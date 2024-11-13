using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MentorJournalAPI_v0._3.Models;

public partial class Admin
{
    public int PersonId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Person? Person { get; set; } = null!;
}
