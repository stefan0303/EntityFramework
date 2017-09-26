namespace PlanetHunters.Export
{
    using Data.Stores;
    using System.Xml.Serialization;
    using System.IO;
    using Data.Dtos.Export;

    public class XmlExport
    {
        public static void ExportStars()
        {
            var stars = StarStore.GetFlat();
            var serializer = new XmlSerializer(typeof(StarCollectionDto));

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            using (var writer = new StreamWriter("../../../export/stars.xml"))
            {
                serializer.Serialize(writer, stars, ns);
            }
        }
    }
}
