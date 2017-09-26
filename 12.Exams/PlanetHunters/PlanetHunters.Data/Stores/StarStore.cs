namespace PlanetHunters.Data.Stores
{
    using System;
    using System.Collections.Generic;
    using Dtos.Import;
    using System.Linq;
    using Models;
    using Dtos.Export;

    public class StarStore
    {
        public static void AddStars(ICollection<StarImportDto> stars)
        {
            var filteredStars = new List<StarImportDto>();
            foreach (var starDto in stars)
            {
                if (starDto.Name == null || starDto.Temperature < 2400 || starDto.StarSystem == null)
                {
                    Console.WriteLine("Invalid data");
                }
                else
                {
                    filteredStars.Add(starDto);
                    Console.WriteLine($"Record {starDto.Name} successfully imported.");
                }
            }

            StarSystemStore.AddStarSystems(filteredStars.Select(s => s.StarSystem).Distinct().ToList());

            using (var context = new PlanetHuntersContext())
            {
                context.Stars.AddRange(filteredStars.Select(s => new Star
                {
                    Name = s.Name,
                    Temperature = s.Temperature,
                    StarSystemId = StarSystemStore.GetSystemByName(s.StarSystem, context).Id
                }));
                context.SaveChanges();
            }
        }

        public static StarCollectionDto GetFlat()
        {
            using (var context = new PlanetHuntersContext())
            {
                var result = context.Stars.Select(s => new StarExportDto
                {
                    Name = s.Name,
                    Temperature = s.Temperature,
                    StarSystem = s.StarSystem.Name,
                    DiscoveryInfo = new DiscoveryInfo
                    {
                        Astronomers = s.Discovery.Pioneers
                        .Select(d => new AstronomerDto
                        {
                            Name = d.FirstName + " " + d.LastName,
                            Pioneer = true
                        })
                        .Union(s.Discovery.Observers.Select(c => new AstronomerDto
                        {
                            Name = c.FirstName + " " + c.LastName,
                            Pioneer = false
                        })
                            .ToList())
                        .ToList(),
                        DiscoveryDate = s.Discovery.DateMade.ToString(),
                        TelescopeName = s.Discovery.Telescope.Name
                    }
                }).ToList();
                return new StarCollectionDto { Stars = result };
            }
        }

        public static Star GetStarByName(string name, PlanetHuntersContext context)
        {
            return context.Stars.FirstOrDefault(s => s.Name == name);
        }
    }
}
