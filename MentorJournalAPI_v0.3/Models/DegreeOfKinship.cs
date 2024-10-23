using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class DegreeOfKinship
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Parent> Parents { get; set; } = new List<Parent>();
}
