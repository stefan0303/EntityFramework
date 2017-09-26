namespace PlanetHunters.Models
{
    using System.Collections.Generic;

    public class Telescope
    {
        public Telescope()
        {
            this.Discoveries = new HashSet<Discovery>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public float? MirrorDiameter { get; set; }
        public virtual ICollection<Discovery> Discoveries { get; set; }
    }
}
