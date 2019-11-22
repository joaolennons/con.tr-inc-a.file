using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Write.Pocos
{
    public class Participant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Presence> Presences { get; set; }
    }
}
