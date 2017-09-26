namespace PlanetHunters.Data.Dtos.Export
{
    using System.Collections.Generic;

    public class PlanetExportDto
    {
        public string Name { get; set; }
        public float Mass { get; set; }
        public IEnumerable<string> Orbiting { get; set; }
    }
}
