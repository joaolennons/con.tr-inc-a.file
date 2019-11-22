using System;

namespace Read.Dtos
{
    internal class BarbecueDetail
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public Guid ParticipantId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
