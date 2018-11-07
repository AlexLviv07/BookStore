using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore01.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { set; get; }
        public DbSet<Genre> Genres { set; get; }
    }

    class BookDBInitializer : DropCreateDatabaseIfModelChanges<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            var genre1 = new Genre { Name = "П'єса" };
            var genre2 = new Genre { Name = "Новела" };
            var genre3 = new Genre { Name = "Роман" };
            var genre4 = new Genre { Name = "Поема" };
            context.Genres.AddRange(new List<Genre> {genre1, genre2, genre3, genre4 });
            context.SaveChanges();
            context.Books.Add(new Book { Name = "На західному фронті без змін", Author = "Ерік Марія Ремарк", GenreId = genre3.Id, YearRelease = 2013 });
            context.Books.Add(new Book { Name = "Катерина", Author = "Тарас Шевченко", GenreId = genre4.Id, YearRelease = 2006 });
            context.Books.Add(new Book { Name = "Новина", Author = "Василь Стефаник", GenreId = genre2.Id, YearRelease = 2015 });
            context.Books.Add(new Book { Name = "Лісова пісня", Author = "Леся Українка", GenreId = genre1.Id, YearRelease = 2004 });
            base.Seed(context);
        }
    }
}