namespace PlanetHunters.Data
{
    public static class Utility
    {
        public static PlanetHuntersContext GetContext()
        {
            return new PlanetHuntersContext();
        }
    }
}
