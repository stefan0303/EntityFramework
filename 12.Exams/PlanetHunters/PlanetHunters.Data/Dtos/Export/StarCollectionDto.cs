namespace PlanetHunters.Data.Dtos.Export
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("Stars")]
    public class StarCollectionDto
    {
        [XmlElement("Star")]
        public List<StarExportDto> Stars { get; set; }
    }
}
