﻿namespace webapi.Controllers
{
    public class CandidateDTO
    {
        public int CandidateId { get; set; }
        public string? Name { get; set; }
        public string? Account { get; set; }
        public string? Password { get; set; }
    }
}