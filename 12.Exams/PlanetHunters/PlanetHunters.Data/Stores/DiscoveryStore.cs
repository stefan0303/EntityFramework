namespace PlanetHunters.Data.Stores
{
    using System;
    using Models;
    using System.Collections.Generic;
    using Dtos.Import;
    using System.Linq;

    public class DiscoveryStore
    {
        public static void AddDiscoveries(ICollection<DiscoveryImportDto> discoveries)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var discoveryDto in discoveries)
                {
                    var stars = discoveryDto.Stars.Select(s => StarStore.GetStarByName(s, context)).ToList();
                    var planets = discoveryDto.Planets.Select(p => PlanetStore.GetPlanetByName(p, context)).ToList();
                    var pioneers = discoveryDto.Pioneers.Select(p => AstronomerStore.GetAstronomerByName(p, context)).ToList();
                    var observers = discoveryDto.Observers.Select(o => AstronomerStore.GetAstronomerByName(o, context)).ToList();

                    if (discoveryDto.DateMade == null ||
                        discoveryDto.Telescope == null ||
                        stars.Any(s => s == null) ||
                        planets.Any(p => p == null) ||
                        pioneers.Any(a => a == null) ||
                        observers.Any(a => a == null))
                    {
                        Console.WriteLine("Invalid data");
                    }
                    else
                    {
                        var discovery = new Discovery
                        {
                            DateMade = DateTime.Parse(discoveryDto.DateMade),
                            Telescope = TelescopeStore.GetTelescopeByName(discoveryDto.Telescope, context),
                            Stars = stars,
                            Planets = planets,
                            Pioneers = pioneers,
                            Observers = observers
                        };
                        context.Discoveries.Add(discovery);
                        Console.WriteLine($"Discovery ({discoveryDto.DateMade}-{discoveryDto.Telescope}) with {discoveryDto.Stars.Count} star(s), {discoveryDto.Planets.Count} planet(s), {discoveryDto.Pioneers.Count} pioneer(s) and {discoveryDto.Observers.Count} observers successfully  imported.");
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
