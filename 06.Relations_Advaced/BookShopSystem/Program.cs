using System;
using System.Linq;
using BookShopSystem.Data;

namespace BookShopSystem
{

    class Program
    {
        static void Main()
        {
            var context = new BookShopContext();
            //var migrationStrategy = new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>();
            //Database.SetInitializer(migrationStrategy);
            //Console.WriteLine(context.Books.Count());
            var books = context.Books
    .Take(3)
    .ToList();
            books[0].RelatedBooks.Add(books[1]);
            books[1].RelatedBooks.Add(books[0]);
            books[0].RelatedBooks.Add(books[2]);
            books[2].RelatedBooks.Add(books[0]);

            context.SaveChanges();

            var booksFromQuery = context.Books.Take(3);
           
            // Query the first three books to get their names
            // and their related book names
            foreach (var book in booksFromQuery)
            {
                Console.WriteLine("--{0}", book.Title);
                foreach (var relatedBook in book.RelatedBooks)
                {
                    Console.WriteLine(relatedBook.Title);
                }
            }

            //SeedAuthors(context);
            //Console.WriteLine(context.Authors.Count());
            //SeedBooks(context);
            //

            //SeedCategories(context);
            //context.SaveChanges();
        }
    }
}