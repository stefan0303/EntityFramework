using System;
using System.Collections.Generic;
using System.Linq;
using BookShopSystem.Data;
using BookShopSystem.Models;

namespace BookShopSystem
{

    class Program
    {
        static void Main()
        {
            var context = new BookShopContext();

            string command = Console.ReadLine();//Write a command number from 1 to 15

            switch (command)
            {
                case "1" :
                    PrintTitlesOfBooks(context);
                    break;
                case "2":
                    SelectGoldenEditionBooks(context);
                    break;
                case "3":
                    BookByPrice(context);
                    break;
                case "4":
                    NotReleasedBooks(context);
                    break;
                case "5":
                    BookTitlesByCategory(context);
                    break;
                case "6":
                    BooksReleasedBeforeDate(context);
                    break;
                case "7":
                    AuthorsSearch(context);
                    break;
                case "8":
                    BookSearch(context);
                    break;
                case "9":
                    BookTitleSearch(context);
                    break;
                case "10":
                    CountBooks(context);
                    break;
                case "11":
                    TotalBookCopies(context);
                    break;
                case "12":
                    FindProfit(context);
                    break;
                case "13":
                    MostRecentBooks(context);
                    break;
                case "14":
                    IncreaseBookCopies(context);
                    break;
                case "15":
                    RemoveBooks(context);
                    break;
                default :Console.WriteLine("Invalid command!");
                    break;
            }

            //01 PrintTitlesOfBooks(context);
            //02 SelectGoldenEditionBooks(context);
            //03 BookByPrice(context);
            //04 NotReleasedBooks(context);
            //05 BookTitlesByCategory(context);
            //06 BooksReleasedBeforeDate(context);
            //07 AuthorsSearch(context);
            //08  BookSearch(context);
            //09 BookTitleSearch(context);
            //10  CountBooks(context);
            //11 TotalBookCopies(context);
            //12 FindProfit(context);
            //13 MostRecentBooks(context);
            //14 IncreaseBookCopies(context);
            //15  RemoveBooks(context);

        }
        //01
        static void PrintTitlesOfBooks(BookShopContext context)
        {
            string input = Console.ReadLine().ToLower();
                                         
            var books = context.Books.Where(b=>b.AgeRestriction.ToString().ToLower()==input);
            foreach (var book in books)
            {                
                    Console.WriteLine(book.Title);               
            }
        }
        //02
        static void SelectGoldenEditionBooks(BookShopContext context)
        {
            var books =
                context.Books.Where(b => b.Edition.ToString() == "Gold")
                    .Where(b => b.Copies < 5000)
                    .Select(b => b.Title);
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
        //03
        static void BookByPrice(BookShopContext context)
        {
            var books = context.Books.OrderBy(b => b.Id);
            foreach (var book in books)
            {
                if (book.Price<5||book.Price>40)
                {
                    Console.WriteLine(book.Title+" - $"+book.Price);
                }
            }
        }
        //04
        static void NotReleasedBooks(BookShopContext context)
        {
            int year =int.Parse(Console.ReadLine());

            var books = context.Books.OrderBy(b=>b.Id).Where(b => b.ReleaseDate.Year != year).Select(b=>b.Title);
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

        }
        //05
        static void BookTitlesByCategory(BookShopContext context)
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
           // string input = "fantasy";
            var books = context.Books;
            List<Book> selectedBooks=new List<Book>();
            for (int i = 0; i < input.Length; i++)
            {
                string cat = input[i];
                var category = context.Categories.Where(c => c.Name.ToLower() == cat).Select(c => c.Id);
                int idOfcategory = 0;
                foreach (var c in category)
                {
                    idOfcategory = c;
                }
                var categoryBooks = context.Books;
                foreach (var book in categoryBooks)
                {
                    foreach (var c in book.Categories)
                    {

                        if (c.Id == idOfcategory)
                        {
                            selectedBooks.Add(book);
                        }

                    }
                }
            }         
            var orderBooks = selectedBooks.OrderBy(b => b.Id).Distinct();
            foreach (var book in orderBooks)
            {
                
                Console.WriteLine(book.Title);
            }
        }
        //06
        static void BooksReleasedBeforeDate(BookShopContext context)
        {
            string[] input = Console.ReadLine().Split('-').ToArray();
            DateTime inputDate = DateTime.Parse(input[2]+"-"+input[1]+"-"+input[0]);

            var books =
                context.Books.Where(d => d.ReleaseDate < inputDate)
                    .Select(b => b.Title + " - " + b.Edition + " - " + b.Price);
            foreach (var b in books)
            {
                Console.WriteLine(b);
            }
        }
        //07
        static void AuthorsSearch(BookShopContext context)
        {
            string endsWith = Console.ReadLine();

            var authors =
                context.Authors.Where(
                        a => a.FirstName.Substring(a.FirstName.Length - endsWith.Length, a.FirstName.Length) == endsWith)
                    .Select(a => a.FirstName + " " + a.LastName);
            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }
        }
        //08
        static void BookSearch(BookShopContext context)
        {
            string input = Console.ReadLine().ToLower();
            var books = context.Books.Where(b => b.Title.ToLower().Contains(input)).Select(b => b.Title);
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
        //09
        static void BookTitleSearch(BookShopContext context)
        {
            string input = Console.ReadLine().ToLower();
            var authors = context.Authors.Where(a => a.LastName.Substring(0, input.Length).ToLower() == input).Select(a=>a.Id);
            List<int> authorIds =new List<int>();
            foreach (var authorId in authors)
            {
              authorIds.Add(authorId);
                
            }
            for (int i = 0; i < authorIds.Count; i++)
            {
                int id = authorIds[i];
                var books = context.Books.OrderBy(b => b.Id).Where(b => b.AuthorId == id).Select(b => b.Title+" ("+b.Author.FirstName+" "+b.Author.LastName+")").Take(1);
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }
           
        }
        //10
        static void CountBooks(BookShopContext context)
        {
            int num = int.Parse(Console.ReadLine());

            int booksCount = context.Books.Where(b => b.Title.Length > num).Select(b => b.Id).Count();      
            Console.WriteLine(booksCount);
        }
        //11
        static void TotalBookCopies(BookShopContext context)
        {
            var authors = context.Authors;
            Dictionary<string,int> authorCopies =new Dictionary<string, int>();
            int bookCopies = 0;
            foreach (var id in authors)
            {
               
                foreach (var book in id.Books)
                {
                    bookCopies += book.Copies;
                }
                authorCopies.Add(id.FirstName + " " + id.LastName + " - ",bookCopies);
                //Console.WriteLine(id.FirstName+" "+id.LastName+" - "+bookCopies);
                bookCopies = 0;
            }
            foreach (var author in authorCopies.OrderByDescending(c=>c.Value))
            {
                Console.WriteLine(author.Key+author.Value);
            }
          //  var books = context.Books.OrderByDescending(c => c.Copies).Count();
        }
        //12
        static void FindProfit(BookShopContext context)
        {
            var categories = context.Categories;
            decimal sum = 0;
            Dictionary<string,decimal> categoryPrice=new Dictionary<string, decimal>();
            foreach (var categorie in categories)
            {
                foreach (var book in categorie.Books)
                {
                    sum+= book.Price * book.Copies;
                }
                categoryPrice.Add(categorie.Name,sum);
                sum = 0;
            }
            foreach (var k in categoryPrice.OrderByDescending(v=>v.Value).ThenBy(v=>v.Key))
            {
                Console.WriteLine(k.Key+" - $"+k.Value);
            }
        }
        //13
        static void MostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories.Where(c => c.Books.Count > 35)
                .OrderByDescending(b => b.Books.Count);

            foreach (var categorie in categories)
            {
                Console.WriteLine("--"+categorie.Name+": "+categorie.Books.Count+" books");
                foreach (var book in categorie.Books.OrderByDescending(b=>b.ReleaseDate).ThenBy(b=>b.Title).Take(3))
                {
                    Console.WriteLine(book.Title+" ("+book.ReleaseDate.Year+")");
                }                
            }
        }
       // 14
        static void IncreaseBookCopies(BookShopContext context)
        {
            DateTime date = DateTime.Parse("2013/06/06");


            var books = context.Books.Where(b => b.ReleaseDate > date);
            foreach (var book in books)
            {
                book.Copies += 44;
            }
            Console.WriteLine(books.Count()+ " books are released after 6 Jun 2013 so total of "+books.Count()*44+ " book copies were added");
        }
        //15
        static void RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Copies < 4200);
            foreach (var book in books)
            {
                context.Books.Remove(book);
            }
            Console.WriteLine(books.Count()+ " books were deleted");
            context.SaveChanges();
        }

       
    }
}