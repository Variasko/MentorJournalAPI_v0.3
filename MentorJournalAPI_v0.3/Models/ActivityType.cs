using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MentorJournalAPI_v0._3.Models;

public partial class ActivityType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Activist>? Activists { get; set; } = new List<Activist>();
}
