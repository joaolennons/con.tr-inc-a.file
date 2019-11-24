using System;

namespace Api.ViewModels
{
    public class Barbecue
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
    }
}
