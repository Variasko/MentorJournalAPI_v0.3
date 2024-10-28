
namespace MentorJournalAPI_v0._3.DTOs
{
    public class IndividualWordWithStudentDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Result { get; set; } = null!;
        public DateOnly Date { get; set; }
        public int StudentId { get; set; }
    }
}
