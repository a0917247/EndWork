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
        public string Account { get; internal set; }
        public string Category { get; internal set; }
        public string CompanyName { get; internal set; }
        public string Address { get; internal set; }
        public string Info { get; internal set; }
        public string UniformNumbers { get; internal set; }
    }
}