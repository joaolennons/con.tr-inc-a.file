using System;
using System.Collections.Generic;

namespace Read.Dtos
{
    public class BarbecueInfo
    {
        public Guid Id { get; internal set; }
        public string Description { get; internal set; }
        public decimal TotalAmount { get; internal set; }
        public int TotalParticipants { get; internal set; }
        public IEnumerable<Participant> Participants { get; private set; }
        public DateTime Date { get; internal set; }
        public DateTime? UpdateDate { get; set; }

        public BarbecueInfo AddParticipants(IEnumerable<Participant> participants)
        {
            Participants = participants;
            return this;
        }

        public class Participant
        {
            public Participant(Guid id, string name, decimal value, bool paid)
            {
                Id = id;
                Name = name;
                Value = value;
                Paid = paid;
            }

            public Guid Id { get; }
            public string Name { get; }
            public decimal Value { get; }
            public bool Paid { get; }
        }
    }
}
