
namespace MentorJournalAPI_v0._3.DTOs
{
    public class GroupDto
    {
        public int Id { get; set; }
        public int MentorId { get; set; }
        public int SpecificationId { get; set; }
        public bool IsBuget { get; set; }
        public DateOnly RecruitmentDate { get; set; }
    }
}
