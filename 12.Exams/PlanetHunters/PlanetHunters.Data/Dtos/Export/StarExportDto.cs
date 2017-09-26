namespace PlanetHunters.Data.Dtos.Export
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("Star")]
    public class StarExportDto
    {
        public string Name { get; set; }
        public int Temperature { get; set; }
        public string StarSystem { get; set; }
        public DiscoveryInfo DiscoveryInfo { get; set; }
    }

    public class DiscoveryInfo
    {
        [XmlAttribute]
        public string DiscoveryDate { get; set; }
        [XmlAttribute]
        public string TelescopeName { get; set; }

        [XmlElement("Astronomer")]
        public List<AstronomerDto> Astronomers { get; set; }
    }

    public class AstronomerDto
    {
        [XmlText]
        public string Name { get; set; }
        [XmlAttribute]
        public bool Pioneer { get; set; }
    }
}
