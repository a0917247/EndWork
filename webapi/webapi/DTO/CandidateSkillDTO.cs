namespace webapi.Controllers
{
    public class CandidateSkillDTO
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? SkillId { get; set; }
        public string? SkillName { get; set; }
    }
}