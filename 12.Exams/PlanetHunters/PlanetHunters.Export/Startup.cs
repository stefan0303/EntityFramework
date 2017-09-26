namespace PlanetHunters.Export
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            JsonExport.ExportPlanets("TRAPPIST");
            JsonExport.ExportAstronomers("Alpha Centauri");
            XmlExport.ExportStars();
        }
    }
}
