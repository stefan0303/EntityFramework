namespace PlanetHunters.Models
{
    public class Star
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Temperature { get; set; }
        public int StarSystemId { get; set; }
        public virtual StarSystem StarSystem { get; set; }
        public int? DiscoveryId { get; set; }
        public virtual Discovery Discovery { get; set; }
    }
}
