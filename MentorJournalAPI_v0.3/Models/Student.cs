using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class Student
{
    public int PersonId { get; set; }

    public bool IsRemoved { get; set; }

    public DateOnly? RemovingDate { get; set; }

    public virtual ICollection<Activist> Activists { get; set; } = new List<Activist>();

    public virtual ICollection<AttendClassHour> AttendClassHours { get; set; } = new List<AttendClassHour>();

    public virtual ICollection<Dormitory> Dormitories { get; set; } = new List<Dormitory>();

    public virtual ICollection<Hobbie> Hobbies { get; set; } = new List<Hobbie>();

    public virtual ICollection<IndividualWordWithStudent> IndividualWordWithStudents { get; set; } = new List<IndividualWordWithStudent>();

    public virtual ICollection<ObservationList> ObservationLists { get; set; } = new List<ObservationList>();

    public virtual ICollection<Parent> Parents { get; set; } = new List<Parent>();

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<SocialPassport> SocialPassports { get; set; } = new List<SocialPassport>();

    public virtual ICollection<StudentInGroup> StudentInGroups { get; set; } = new List<StudentInGroup>();
}
