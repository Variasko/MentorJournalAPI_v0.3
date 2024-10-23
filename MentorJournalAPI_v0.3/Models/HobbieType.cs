using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class HobbieType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Hobbie> Hobbies { get; set; } = new List<Hobbie>();
}
