using webapi.Models;

namespace webapi.Controllers
{
    public class OrderDetailDTO : CourseOrder
    {
        public int OrderId { get; set; }
        public int? CandidateId { get; set; }
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        public int? Price { get; set; }
        public DateTime? Buyingtime { get; set; }
    }
}