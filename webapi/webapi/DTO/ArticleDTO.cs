namespace webapi.DTO
{
    public class ArticleDTO
    {
        public string Title { get; set; }
        public string ArticleContent { get; set; }
        public string Img { get;  set; }
        public DateTime? UpdateTime { get; set; }
        public string? Author { get; set; }
        public string? Update { get;  set; }
        public int? ArticleId { get;  set; }
        public string? Expreience { get;  set; }
    }
}