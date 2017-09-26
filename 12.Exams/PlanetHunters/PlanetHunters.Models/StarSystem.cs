namespace PlanetHunters.Models
{
    using System.Collections.Generic;

    public class StarSystem
    {
        public StarSystem()
        {
            this.Stars = new HashSet<Star>();
            this.Planets = new HashSet<Planet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Star> Stars { get; set; }
        public virtual ICollection<Planet> Planets { get; set; }
    }
}
