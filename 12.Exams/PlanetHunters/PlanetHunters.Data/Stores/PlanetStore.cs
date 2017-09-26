namespace PlanetHunters.Data.Stores
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Dtos.Import;
    using System.Linq;
    using Dtos.Export;

    public class PlanetStore
    {
        public static void AddPlanets(ICollection<PlanetImportDto> planets)
        {

            var filteredPlanets = new List<PlanetImportDto>();
            foreach (var planetDto in planets)
            {
                if (planetDto.Name == null || planetDto.Mass <= 0 || planetDto.StarSystem == null)
                {
                    Console.WriteLine("Invalid data");
                }
                else
                {
                    filteredPlanets.Add(planetDto);
                    Console.WriteLine($"Record {planetDto.Name} successfully imported.");
                }
            }

            StarSystemStore.AddStarSystems(filteredPlanets.Select(p => p.StarSystem).Distinct().ToList());

            using (var context = new PlanetHuntersContext())
            {
                context.Planets.AddRange(filteredPlanets.Select(p => new Planet
                {
                    Name = p.Name,
                    Mass = p.Mass,
                    StarSystemId = StarSystemStore.GetSystemByName(p.StarSystem, context).Id
                }));
                context.SaveChanges();
            }
        }

        public static object GetPlanetsByObservatory(string telescopeName)
        {
            using (var context = new PlanetHuntersContext())
            {
                var planets = context.Planets
                    .Where(p => p.Discovery.Telescope.Name == telescopeName)
                    .Select(p => new PlanetExportDto
                    {
                        Name = p.Name,
                        Mass = p.Mass,
                        Orbiting = p.StarSystem.Stars.Select(s => s.Name)
                    })
                    .OrderByDescending(p => p.Mass)
                    .ToList();

                return planets;
            }
        }

        public static Planet GetPlanetByName(string name, PlanetHuntersContext context)
        {
            return context.Planets.FirstOrDefault(p => p.Name == name);
        }
    }
}
