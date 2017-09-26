using System.Xml;

namespace PlanetHunters.Export
{
    using Data.Stores;
    using Models;
    using Newtonsoft.Json;
    using System.IO;
    using System;

    public class JsonExport
    {
        public static void ExportPlanets(string observatoryName)
        {
            var planets = PlanetStore.GetPlanetsByObservatory(observatoryName);

            File.WriteAllText($"../../../export/planets-by-{observatoryName}.json", JsonConvert.SerializeObject(planets, Formatting.Indented));
        }

        public static void ExportAstronomers(string starSystemName)
        {
            var astronomers = AstronomerStore.GetAstronomersBySystem(starSystemName);

            File.WriteAllText($"../../../export/astronomers-of-{starSystemName}.json", JsonConvert.SerializeObject(astronomers, Formatting.Indented));
        }
    }
}
