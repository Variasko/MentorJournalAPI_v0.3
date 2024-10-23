using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MentorJournalAPI_v0._3.Models;

public partial class Activist
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int ActivityTypeId { get; set; }
    [JsonIgnore]
    public virtual ActivityType? ActivityType { get; set; } = null!;
    [JsonIgnore]
    public virtual Student? Student { get; set; } = null!;
}
