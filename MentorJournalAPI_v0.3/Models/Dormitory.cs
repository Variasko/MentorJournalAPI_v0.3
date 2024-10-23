using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class Dormitory
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int RoomNumber { get; set; }

    public virtual Student Student { get; set; } = null!;
}
