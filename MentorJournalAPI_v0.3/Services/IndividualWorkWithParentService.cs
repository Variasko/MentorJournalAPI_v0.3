
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentorJournalAPI_v0._3.DTOs;
using MentorJournalAPI_v0._3.Interfaces;

namespace MentorJournalAPI_v0._3.Services
{
public class IndividualWorkWithParentService : IIndividualWorkWithParentService
    {
        public MentorJournalV02Context _context;

        public ObservationListService(MentorJournalV02Context context)
        {
            _context = context;
        }
    }
}
