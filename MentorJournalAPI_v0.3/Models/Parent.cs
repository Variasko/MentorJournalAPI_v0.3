using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class Parent
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int StudentId { get; set; }

    public int DegreeOfKinshipId { get; set; }

    public virtual DegreeOfKinship DegreeOfKinship { get; set; } = null!;

    public virtual ICollection<IndividualWorkWithParent> IndividualWorkWithParents { get; set; } = new List<IndividualWorkWithParent>();

    public virtual Student Student { get; set; } = null!;
}
