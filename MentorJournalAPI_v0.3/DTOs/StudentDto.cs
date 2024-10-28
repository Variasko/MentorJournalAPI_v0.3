
namespace MentorJournalAPI_v0._3.DTOs
{
    public class StudentDto
    {
        public int PersonId { get; set; }
        public bool IsRemoved { get; set; }
        public DateOnly? RemovingDate { get; set; }
    }
}
