using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MentorJournalAPI_v0._3.Models;

public partial class Student
{
    public int PersonId { get; set; }

    public bool IsRemoved { get; set; }

    public DateOnly? RemovingDate { get; set; }

    [JsonIgnore]
    public virtual ICollection<Activist>? Activists { get; set; } = new List<Activist>();
    [JsonIgnore]
    public virtual ICollection<AttendClassHour>? AttendClassHours { get; set; } = new List<AttendClassHour>();
    [JsonIgnore]
    public virtual ICollection<Dormitory>? Dormitories { get; set; } = new List<Dormitory>();
    [JsonIgnore]
    public virtual ICollection<Hobbie>? Hobbies { get; set; } = new List<Hobbie>();
    [JsonIgnore]
    public virtual ICollection<IndividualWordWithStudent>? IndividualWordWithStudents { get; set; } = new List<IndividualWordWithStudent>();
    [JsonIgnore]
    public virtual ICollection<ObservationList>? ObservationLists { get; set; } = new List<ObservationList>();
    [JsonIgnore]
    public virtual ICollection<Parent>? Parents { get; set; } = new List<Parent>();
    [JsonIgnore]
    public virtual Person? Person { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<SocialPassport>? SocialPassports { get; set; } = new List<SocialPassport>();
    [JsonIgnore]
    public virtual ICollection<StudentInGroup>? StudentInGroups { get; set; } = new List<StudentInGroup>();
}
