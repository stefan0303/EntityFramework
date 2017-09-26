namespace PlanetHunters.Data.Stores
{
    using Dtos.Export;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class AstronomerStore
    {
        public static void AddAstronomers(ICollection<Astronomer> astronomers)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var astronomer in astronomers)
                {
                    if (astronomer.FirstName == null || astronomer.LastName == null)
                    {
                        Console.WriteLine("Invalid data");
                    }
                    else
                    {
                        context.Astronomers.Add(astronomer);
                        Console.WriteLine($"Record {astronomer.FirstName} {astronomer.LastName} successfully imported.");
                    }
                }
                context.SaveChanges();
            }
        }

        public static object GetAstronomersBySystem(string starSystemName)
        {
            using (var context = new PlanetHuntersContext())
            {
                var starSystem = context.StarSystems.Where(ss => ss.Name == starSystemName).FirstOrDefault();

                var starPeople = new List<AstronomerRoleDto>();

                var col1 = starSystem.Stars.Select(s =>
                            s.Discovery.Pioneers.Select(a => new AstronomerRoleDto
                            {
                                FirstName = a.FirstName,
                                LastName = a.LastName,
                                Role = "pioneer"
                            }).ToList()
                            .Union(s.Discovery.Observers.Select(a => new AstronomerRoleDto
                            {
                                FirstName = a.FirstName,
                                LastName = a.LastName,
                                Role = "observer"
                            }).ToList()).ToList()
                            );
                foreach (var item in col1)
                {
                    starPeople = starPeople.Union(item).ToList();
                }

                var planetPeople = new List<AstronomerRoleDto>();

                var col2 = starSystem.Planets.Select(s =>
                            s.Discovery.Pioneers.Select(a => new AstronomerRoleDto
                            {
                                FirstName = a.FirstName,
                                LastName = a.LastName,
                                Role = "pioneer"
                            }).ToList()
                            .Union(s.Discovery.Observers.Select(a => new AstronomerRoleDto
                            {
                                FirstName = a.FirstName,
                                LastName = a.LastName,
                                Role = "observer"
                            }).ToList()).ToList()
                            );
                foreach (var item in col2)
                {
                    planetPeople = planetPeople.Union(item).ToList();
                }

                var result = starPeople.Union(planetPeople).OrderBy(a => a.LastName).Select(a => new AstronomerExportDto
                {
                    Name = a.FirstName + " " + a.LastName,
                    Role = a.Role
                });

                return result.GroupBy(a => new { a.Name, a.Role }).Select(g => g.First()).ToList();
            }
        }

        public static Astronomer GetAstronomerByName(string name, PlanetHuntersContext context)
        {
            var nameTokens = name.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
            var firstName = nameTokens[1];
            var lastName = nameTokens[0];
            return context.Astronomers.FirstOrDefault(a => a.FirstName == firstName && a.LastName == lastName);
        }
    }
}
