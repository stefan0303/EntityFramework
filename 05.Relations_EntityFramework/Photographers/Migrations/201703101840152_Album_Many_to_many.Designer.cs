// <auto-generated />
namespace Photographers.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class Album_Many_to_many : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Album_Many_to_many));
        
        string IMigrationMetadata.Id
        {
            get { return "201703101840152_Album_Many_to_many"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return Resources.GetString("Source"); }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
