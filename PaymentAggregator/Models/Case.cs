using System;

namespace PaymentAggregator.Models
{
    public class Case
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Title { get; set; }
        public string BriefDescription { get; set; }
        public string FullContent { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}