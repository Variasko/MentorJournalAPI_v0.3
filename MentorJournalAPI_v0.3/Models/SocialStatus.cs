using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class SocialStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SocialPassport> SocialPassports { get; set; } = new List<SocialPassport>();
}
