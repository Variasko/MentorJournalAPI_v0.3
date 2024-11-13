
namespace MentorJournalAPI_v0._3.DTOs
{
    public class ObservationListDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Characteristic { get; set; } = null!;
        public DateOnly Date { get; set; }
    }
}
