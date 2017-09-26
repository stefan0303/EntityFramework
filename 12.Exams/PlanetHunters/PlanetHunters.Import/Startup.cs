namespace PlanetHunters.Import
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            JsonImport.ImportAstronomers();
            JsonImport.ImportTelescopes();
            JsonImport.ImportPlanets();
            XmlImport.ImportStars();
            XmlImport.ImportDiscoveries();
        }
    }
}
