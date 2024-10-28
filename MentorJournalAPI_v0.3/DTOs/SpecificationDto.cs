
namespace MentorJournalAPI_v0._3.DTOs
{
    public class SpecificationDto
    {
        public int Id { get; set; }
        public string Direction { get; set; } = null!;
        public string? Specialization { get; set; }
        public string ReductionDirection { get; set; } = null!;
        public string? ReductionSpecialization { get; set; }
    }
}
