using System;
using System.Collections.Generic;

namespace MentorJournalAPI_v0._3.Models;

public partial class Person
{
    public int Id { get; set; }

    public byte[]? Photo { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public bool Gender { get; set; }

    public DateOnly Bithday { get; set; }

    public string PassportSeial { get; set; } = null!;

    public string PassportNumber { get; set; } = null!;

    public string Snils { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string RegistrationAddress { get; set; } = null!;

    public string LivingAddress { get; set; } = null!;

    public virtual Admin? Admin { get; set; }

    public virtual Mentor? Mentor { get; set; }

    public virtual Student? Student { get; set; }
}
