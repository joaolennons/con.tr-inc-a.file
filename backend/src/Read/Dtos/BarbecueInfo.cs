using System.Collections.Generic;
using System.Linq;

namespace Read.Dtos
{
    public class BarbecueInfo
    {
        public decimal TotalAmount => Participants.Sum(o => o.Value);
        public int TotalParticipants => Participants.Count();
        public IEnumerable<Participant> Participants { get; set; }
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
