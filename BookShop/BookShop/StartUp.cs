namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            string books = "";
            int booksCount = 0;
            // int year = int.Parse(Console.ReadLine());
            //string date = Console.ReadLine();
            // string input = Console.ReadLine();

            //int length = int.Parse(Console.ReadLine());

            string profits = "";
            
            using (var db = new BookShopContext())
            {

                //books = GetBooksByPrice(db);

                // books = GetBooksNotRealeasedIn(db, year);

                //   books = GetBooksReleasedBefore(db, date);

                //   books = GetBooksByCategory(db, input);
                //books = GetAuthorNamesEndingIn(db, input);

                //    books = GetBookTitlesContaining(db, input);

                // books = GetBooksByAuthor(db, input);
                // Console.WriteLine(books);

                //  booksCount = CountBooks(db, length);
                //  Console.WriteLine(booksCount)


                //   profits = GetTotalProfitByCategory(db);

                //  Console.WriteLine(profits);

                //  string copies = CountCopiesByAuthor(db);
                // Console.WriteLine(copies);

                GetMostRecentBooks(db);
            }
           
        }

        public static string GetBooksByPrice(BookShopContext context) 
        {

            var books = context.Books.OrderByDescending(e => e.Price).Where(e => e.Price > 40)
                .Select(e => $"{e.Title} - ${e.Price:f2}").ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {

            var titles = context.Books.OrderBy(x => x.BookId).Where(x => x.ReleaseDate.Value.Year != year)
                .Select(x=>x.Title)
                .ToList();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {

                DateTime givendate= DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books.OrderByDescending(e=>e.ReleaseDate)
                .Where(e=>e.ReleaseDate<givendate)
                .Select(e=>$"{e.Title} - {e.EditionType} - ${e.Price:f2}").ToList();



            return string.Join(Environment.NewLine, books);
        }


        public static string GetBooksByCategory(BookShopContext context, string input)
        {

            var categories = input.ToLower().Split().ToList();

            var tittles = context.Books.OrderBy(e => e.Title)
              .Where(e=>e.BookCategories.Any(x=>categories.Contains(x.Category.Name.ToLower())==true))
            .Select(x=>x.Title)
            .ToList();




            return string.Join(Environment.NewLine, tittles);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {


            int length = input.Length;

            var author = context.Authors
                .Where(x => x.FirstName.Substring(x.FirstName.Length - length, length) == input)
                .Select(x => $"{x.FirstName} {x.LastName}").OrderBy(x => x).ToList();

            return string.Join(Environment.NewLine, author);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            input = input.ToLower();
            var title = context.Books.Where(x => x.Title.ToLower().Contains(input) == true)
                .Select(x => x.Title).OrderBy(x => x).ToList();

            return string.Join(Environment.NewLine, title);
        }


        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            input = input.ToLower();
            int length = input.Length;
          

            var titles = context.Books.Include(x => x.Author)
                .OrderBy(x => x.BookId)
                .Where(x => x.Author.LastName.ToLower().Substring(0,length)==input)
                .Select(x => $"{x.Title} ({x.Author.FirstName} {x.Author.LastName})").ToList();

            return string.Join(Environment.NewLine, titles);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int numberofBooks = context.Books.Where(x => x.Title.Length > lengthCheck)
                .Count();

            return numberofBooks;
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
                    

            List<string> profits=new List<string>();
            var profit = context.Categories.Select(x => new
            {
                x.Name,
                TotalProfit = x.CategoryBooks.Sum(e => e.Book.Price * e.Book.Copies)
            }).OrderByDescending(x => x.TotalProfit).ThenBy(x => x.Name).ToList();

            foreach (var item in profit)
            {
                profits.Add($"{item.Name} ${item.TotalProfit:f2}");

            }

            return string.Join(Environment.NewLine, profits);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            List<string> copies = new List<string>();
            var authorcopies = context.Authors
                    .Select(x => new
                {

                    x.FirstName,
                    x.LastName,
                    totalcopies = x.Books.Sum(e => e.Copies)

                }).OrderByDescending(x => x.totalcopies).ToList();

            foreach (var item in authorcopies)
            {
                copies.Add($"{item.FirstName} {item.LastName} - {item.totalcopies}");
            }

            return string.Join(Environment.NewLine, copies);
        }


        public static void GetMostRecentBooks(BookShopContext context)
        {

            var categories = context.Categories
                .OrderBy(e => e.Name)
                .Select(e => new {
                    e.Name,
                    books = e.CategoryBooks.Select(x => new
                    {
                        x.Book.Title,
                        x.Book.ReleaseDate
                    }).OrderByDescending(x => x.ReleaseDate).Take(3).ToList()
                }).ToList();

            foreach (var item in categories)
            {
                Console.WriteLine($"--{item.Name}");

                foreach (var item1 in item.books)
                {
                    Console.WriteLine($"{item1.Title} ({item1.ReleaseDate.Value.Year})");
                }
          
            }
        }
    }
}