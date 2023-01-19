namespace webapi.Controllers
{
    public class EnterpriseDTO
    {
        public int EnterpriseId { get; set; } 
        public string? Principal { get; set; }
        public string? Account { get; set; }
        public string? Password { get; set; }
        public int? VacancyId { get; set; }
        public string Address { get; internal set; }
        public string Category { get; internal set; }
        public string CompanyName { get; internal set; }
        public string Img { get; internal set; }
        public string Info { get; internal set; }
        public string Employee { get; internal set; }
    }
}