namespace webapi.Controllers
{
    public class EnterpriseDTO
    {
        public int EnterpriseId { get; set; } 
        public string? Principal { get; set; }
        public string? Account { get; set; }
        public string? Password { get; set; }
    }
}