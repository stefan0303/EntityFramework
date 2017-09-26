namespace PlanetHunters.Models
{
    using System.Collections.Generic;

    public class Astronomer
    {
        public Astronomer()
        {
            this.PioneeringDiscoveries = new HashSet<Discovery>();
            this.ObservedDiscoveries = new HashSet<Discovery>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Discovery> PioneeringDiscoveries { get; set; }
        public virtual ICollection<Discovery> ObservedDiscoveries { get; set; }
    }
}
