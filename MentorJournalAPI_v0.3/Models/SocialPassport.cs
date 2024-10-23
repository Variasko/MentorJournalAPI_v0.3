using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class SocialPassport
{
    public int Id { get; set; }

    public int StudnetId { get; set; }

    public int SocialStatusId { get; set; }

    public virtual SocialStatus SocialStatus { get; set; } = null!;

    public virtual Student Studnet { get; set; } = null!;
}
