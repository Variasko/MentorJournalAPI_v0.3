using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class Group
{
    public int Id { get; set; }

    public int MentorId { get; set; }

    public int SpecificationId { get; set; }

    public bool IsBuget { get; set; }

    public DateOnly RecruitmentDate { get; set; }

    public virtual ICollection<ParentConference> ParentConferences { get; set; } = new List<ParentConference>();

    public virtual Specification Specification { get; set; } = null!;

    public virtual ICollection<StudentInGroup> StudentInGroups { get; set; } = new List<StudentInGroup>();
}
