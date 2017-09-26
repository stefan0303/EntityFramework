namespace PlanetHunters.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Mass { get; set; }
        public int StarSystemId { get; set; }
        public virtual StarSystem StarSystem { get; set; }
        public int? DiscoveryId { get; set; }
        public virtual Discovery Discovery { get; set; }
    }
}
