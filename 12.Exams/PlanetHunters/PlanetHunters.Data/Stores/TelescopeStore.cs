namespace PlanetHunters.Data.Stores
{
    using System;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class TelescopeStore
    {
        public static void AddTelescopes(ICollection<Telescope> telescopes)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var telescope in telescopes)
                {
                    if (telescope.Name == null || telescope.Location == null || telescope.MirrorDiameter <= 0)
                    {
                        Console.WriteLine("Invalid data");
                    }
                    else
                    {
                        context.Telescopes.Add(telescope);
                        Console.WriteLine($"Record {telescope.Name} successfully imported.");
                    }
                }
                context.SaveChanges();
            }
        }

        public static Telescope GetTelescopeByName(string telescope, PlanetHuntersContext context)
        {
            return context.Telescopes.FirstOrDefault(t => t.Name == telescope);
        }
    }
}
