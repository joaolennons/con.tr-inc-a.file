using System;
using System.Collections.Generic;
using System.Linq;

namespace Read.Dtos
{
    public class BarbecueInfo
    {
        public Guid Id { get; internal set; }
        public string Description { get; internal set; }
        public decimal TotalAmount => Participants.Sum(o => o.Value);
        public int TotalParticipants => Participants.Count();
        public IEnumerable<Participant> Participants { get; internal set; }
        public DateTime Date { get; set; }

        public class Participant
        {
            public Participant(string name, decimal value)
            {
                Name = name;
                Value = value;
            }

            public string Name { get; }
            public decimal Value { get; }
        }
    }
}
