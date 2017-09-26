using System;
using System.Linq;

namespace Photographers
{
    class Program
    {
        static void Main()
        {
            PhotographerContext context = new PhotographerContext();
            Console.WriteLine(context.Photographers.Count());
            context.SaveChanges();
            //Photographer gana =context.Photographers.Add( new Photographer
            //{
            //    UserName = "Gana",
            //    Password = "greda",
            //    Email = "dssdsda@mail.bg",
            //    BirthDate = DateTime.Now.AddYears(-33),
            //    RegisterDate = DateTime.Now

            //});
            //Album pleven =context.Albums.Add( new Album
            //{
            //    Name = "Pleven",
            //    BackGroundColor = "Green",
            //    IsPublic = true,
            //    OwnerId = gana//?
            //});
            //context.SaveChanges();

            //Tag tagg = context.Tags.Add(new Tag
            //{
            //    Label = Console.ReadLine()
            //});
            //context.Tags.Add(tagg);


            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    tagg.Label = TagTransofrmer.Transform(tagg.Label);

            //    context.SaveChanges();

            //}
        }

    }
}
