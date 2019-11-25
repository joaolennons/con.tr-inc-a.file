using System;

namespace Api.ViewModels
{
    public class Presence
    {
        public Guid ParticipantId { get; set; }
        public bool Drinking { get; set; }
        public bool Paid { get; set; }
    }
}
