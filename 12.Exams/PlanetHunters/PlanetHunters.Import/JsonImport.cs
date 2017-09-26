namespace PlanetHunters.Import
{
    using Newtonsoft.Json;
    using Models;
    using System.IO;
    using System.Collections.Generic;
    using System;
    using Data;
    using System.Linq;
    using Data.Stores;
    using Data.Dtos.Import;

    public static class JsonImport
    {
        public static void ImportAstronomers()
        {
            var json = File.ReadAllText("../../../datasets/astronomers.json");
            var astronomers = JsonConvert.DeserializeObject<ICollection<Astronomer>>(json);

            AstronomerStore.AddAstronomers(astronomers);
        }

        public static void ImportPlanets()
        {
            var json = File.ReadAllText("../../../datasets/planets.json");
            var planets = JsonConvert.DeserializeObject<ICollection<PlanetImportDto>>(json);

            PlanetStore.AddPlanets(planets);
        }

        public static void ImportTelescopes()
        {
            var json = File.ReadAllText("../../../datasets/telescopes.json");
            var telescopes = JsonConvert.DeserializeObject<ICollection<Telescope>>(json);

            TelescopeStore.AddTelescopes(telescopes);
        }
    }
}
