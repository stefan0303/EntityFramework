namespace PlanetHunters.Data.Stores
{
    using System.Linq;
    using Models;
    using System.Collections.Generic;

    public class StarSystemStore
    {
        public static StarSystem GetSystemByName(string name, PlanetHuntersContext context)
        {
            return context.StarSystems.FirstOrDefault(ss => ss.Name == name);
        }

        public static void AddStarSystems(ICollection<string> starSystems)
        {
            using (var context = new PlanetHuntersContext())
            {
                var existingSystems = context.StarSystems.Select(ss => ss.Name).ToList();
                foreach (var system in starSystems.Where(ss => !existingSystems.Contains(ss)))
                {
                    context.StarSystems.Add(new StarSystem { Name = system });
                }
                context.SaveChanges();
            }
        }
    }
}
