using Photographers.Models;

namespace Photographers.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Photographers.PhotographerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Photographers.PhotographerContext context)
        {
            Photographer dido =new Photographer()
            {
                UserName = "Dido",
                Password = "greda",
                Email = "dsa@mail.bg",
                BirthDate = DateTime.Now.AddYears(-33),
                RegisterDate = DateTime.Now

            };
            //Proveriava dali ima fotograf teo
            context.Photographers.AddOrUpdate(p=>p.UserName,dido);
            context.SaveChanges();//we make update every time

            Picture testPicture =new Picture
            {
                Title = "SumPic",
                Caption = "Samo Levski",
                Path = "C/pictures"
            };
            context.Pictures.AddOrUpdate(i=>i.Title, testPicture);//We make the picture to be Unique
            context.SaveChanges();
            Album sofia =new Album
            {
                Name = "Sofia",
                BackGroundColor = "Green",
                IsPublic = true,
                //OwnerId = dido
            };
            
            context.Albums.AddOrUpdate(a=>a.Name,sofia);//mapping table

            sofia.Pictures.Add(testPicture);//mapping table
            context.SaveChanges();

            Tag moutainTag =new Tag() {Label = "#moutain"};
            context.Tags.AddOrUpdate(t=>t.Label, moutainTag);//mapping table
            context.SaveChanges();
            moutainTag.Albums.Add(sofia);//mapping table
            context.SaveChanges();
        }
    }
}
