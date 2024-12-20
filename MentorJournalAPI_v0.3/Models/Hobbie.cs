﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MentorJournalAPI_v0._3.Models;

public partial class Hobbie
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int HobbieTypeId { get; set; }
    
    public virtual HobbieType? HobbieType { get; set; } = null!;
    
    public virtual Student? Student { get; set; } = null!;
}
