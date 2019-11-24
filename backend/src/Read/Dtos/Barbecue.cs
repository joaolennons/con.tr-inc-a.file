using System;

namespace Read.Dtos
{
    public class BarbecueDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public int TotalParticipants { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalRaised { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
