namespace PlanetHunters.Data.Dtos.Import
{
    using System.Collections.Generic;

    public class DiscoveryImportDto
    {
        public string DateMade { get; set; }
        public string Telescope { get; set; }
        public ICollection<string> Pioneers { get; set; }
        public ICollection<string> Observers { get; set; }
        public ICollection<string> Stars { get; set; }
        public ICollection<string> Planets { get; set; }
    }
}
