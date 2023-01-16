namespace webapi.Controllers
{
    public class EnterpriseDTO
    {
        internal DateTime? updatetime;
        internal string img;

        public int EnterpriseId { get; set; } 
        public string? Principal { get; set; }
        public string? Account { get; set; }
        public string? Password { get; set; }
        public int VacancyId { get; internal set; }
        public string WorkName { get; internal set; }
        public int? Salary { get; internal set; }
        public string WorkPlace { get; internal set; }
        public string Shift { get; internal set; }
        public bool? FullPartTime { get; internal set; }
        public string WorkContent { get; internal set; }
        public int? Seniority { get; internal set; }
        public string Category { get; internal set; }
        public string CompanyName { get; internal set; }
        public string Address { get; internal set; }
        public string Info { get; internal set; }
        public string UniformNumbers { get; internal set; }
        public string Employee { get; internal set; }
    }
}