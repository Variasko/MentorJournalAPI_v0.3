
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;
using MentorJournalAPI_v0._3.Models;

namespace MentorJournalAPI_v0._3.Services
{
public class IndividualWordWithStudentService : IIndividualWordWithStudentService
    {
        public MentorJournalV02Context _context;

        public ObservationListService(MentorJournalV02Context context)
        {
            _context = context;
        }
    }
}
