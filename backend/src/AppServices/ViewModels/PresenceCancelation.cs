﻿using System;

namespace Api.ViewModels
{
    public class PresenceCancelation
    {
        public Guid ParticipantId { get; set; }
        public bool Paid { get; set; }
    }
}
