
namespace MentorJournalAPI_v0._3.DTOs
{
    public class ParentDto
    {
        public int Id { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int StudentId { get; set; }
        public int DegreeOfKinshipId { get; set; }
    }
}
