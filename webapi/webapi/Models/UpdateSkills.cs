namespace webapi.Models
{
    public class UpdateSkills
    {
        public string? CandidateId { get; set; }

        public IEnumerable<string>? SkillName { get; set; }
    }
}
