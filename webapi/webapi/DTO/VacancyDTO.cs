namespace webapi.Controllers
{
    public class VacancyDTO
    {
        internal DateTime? updatetime;
        public string? img { get; set; }

        public string? WorkName { get; set; }
        public string WorkPlace { get; set; }
        public int? Salary { get; set; }
        public bool? FullPartTime { get; set; }
        public string? Shift { get; set; }
        public string? WorkContent { get; set; }
        public int? Seniority { get; set; }
        public string? Account { get; set; }
        public string? Category { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? Info { get; set; }
        public string? UniformNumbers { get; set; }
        public string? Employee { get; set; }
        public int? VacancyId { get; set; }
        public int? EnterpriseId { get; set; }
    }
}