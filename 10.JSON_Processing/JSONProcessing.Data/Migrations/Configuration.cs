namespace JSONProcessing.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}