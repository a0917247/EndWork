namespace webapi.Controllers
{
    public class CandidateDTO
    {
        public int? CandidateId { get; set; }
        public string? Account { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Cellphone { get; set; }
        public DateOnly? Birth { get; set; }
        public string? Address { get; set; }
        public string? Education { get; set; }
        public string? Seniority { get; set; }
        public string? Img { get; set; }
        public string? Autobiography { get; set; }
        public int? EnterpriseId { get; set; }
        public int? VacancyId { get; set; }
        public string? Status { get; set; }
        public string? Workexperience { get; set; }
        public int? interestStatus { get; set; }
        public string? schoolname { get; set; }
        public string? Workexname { get; set; }
    }
}