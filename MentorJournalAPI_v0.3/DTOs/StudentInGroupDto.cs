
namespace MentorJournalAPI_v0._3.DTOs
{
    public class StudentInGroupDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public DateOnly Date { get; set; }
    }
}
