namespace PlanetHunters.Import
{
    using Data.Dtos.Import;
    using Data.Stores;
    using System.Linq;
    using System.Xml.Linq;
    using System;

    public class XmlImport
    {
        public static void ImportStars()
        {
            var xml = XDocument.Load("../../../datasets/stars.xml");
            var stars = xml.Root.Elements().Select(s => new StarImportDto
            {
                Name = s.Element("Name").Value,
                Temperature = int.Parse(s.Element("Temperature").Value),
                StarSystem = s.Element("StarSystem").Value
            }).ToList();

            StarStore.AddStars(stars);
        }

        public static void ImportDiscoveries()
        {
            var xml = XDocument.Load("../../../datasets/discoveries.xml");
            var discoveries = xml.Root.Elements().Select(d => new DiscoveryImportDto
            {
                DateMade = d.Attribute("DateMade").Value,
                Telescope = d.Attribute("Telescope").Value,
                Pioneers = d.Element("Pioneers").Elements().Select(p => p.Value).ToList(),
                Observers = d.Element("Observers").Elements().Select(o => o.Value).ToList(),
                Stars = d.Element("Stars").Elements().Select(s => s.Value).ToList(),
                Planets = d.Element("Planets").Elements().Select(p => p.Value).ToList(),
            }).ToList();

            DiscoveryStore.AddDiscoveries(discoveries);
        }
    }
}
