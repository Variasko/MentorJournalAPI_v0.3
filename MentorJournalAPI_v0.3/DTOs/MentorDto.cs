
namespace MentorJournalAPI_v0._3.DTOs
{
    public class MentorDto
    {
        public int PersonId { get; set; }
        public int CategoryId { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
