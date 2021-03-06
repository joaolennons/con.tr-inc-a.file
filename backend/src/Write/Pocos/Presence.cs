﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Write.Pocos
{
    public class Presence
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public Guid BarbecueId { get; set; }
        public Barbecue Barbecue { get; set; }
        public Guid ParticipantId { get; set; }
        public Participant Participant { get; set; }
        public bool Paid { get; set; }

        public Presence()
        {

        }

        public Presence(decimal value, Guid barbecueId, Guid participantId)
        {
            Id = Guid.NewGuid();
            Value = value;
            BarbecueId = barbecueId;
            ParticipantId = participantId;
        }
    }
}