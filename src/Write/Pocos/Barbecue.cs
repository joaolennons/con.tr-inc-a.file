using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Write.Pocos
{
    public class Barbecue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public virtual ICollection<Presence> Presences { get; set; }

    }
}
