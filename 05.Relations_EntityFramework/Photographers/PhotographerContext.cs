using Photographers.Migrations;
using Photographers.Models;

namespace Photographers
{
    using System.Data.Entity;

    public class PhotographerContext : DbContext 
    {
        
        // Your context has been configured to use a 'Models' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Photographers.Models' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Models' 
        // connection string in the application configuration file.
        public PhotographerContext()
            : base("name=Models")
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotographerContext, Configuration>());
        }      

        public virtual IDbSet<Photographer> Photographers { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Picture> Pictures { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }
    }

}