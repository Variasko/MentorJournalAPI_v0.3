
namespace MentorJournalAPI_v0._3.DTOs
{
    public class AttendClassHourDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassHourId { get; set; }
        public bool IsVisited { get; set; }
    }
}
