using BookStoreApi.Models.Entities;

// Generate data for test purposes.
namespace BookStoreApi.DbOperations
{
    public class DataGenerator
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            BookStoreDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookStoreDbContext>();
            if (!context.Books.Any())
            {
                context.Authors.AddRange(
                    new Author
                    {
                        AuthorName = "Eric",
                        AuthorSurname = "Ries",
                        AuthorBirthday = new DateTime(1978, 09, 22)
                    },
                    new Author
                    {
                        AuthorName = "Charlotte",
                        AuthorSurname = "Perkins",
                        AuthorBirthday = new DateTime(1860, 7, 3)
                    },
                    new Author
                    {
                        AuthorName = "Frank",
                        AuthorSurname = "Herbert",
                        AuthorBirthday = new DateTime(1920, 10, 8)
                    });
                context.Books.AddRange(
                    new Book
                    {
                        BookTitle = "Lean Startup",
                        GenreId = 1,
                        AuthorId = 1,
                        BookPageCount = 200,
                        BookPublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        BookTitle = "Herland",
                        GenreId = 2,
                        AuthorId = 2,
                        BookPageCount = 250,
                        BookPublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        BookTitle = "Dune",
                        GenreId = 2,
                        AuthorId = 3,
                        BookPageCount = 540,
                        BookPublishDate = new DateTime(2001, 12, 21)
                    }
                );
                context.Genres.AddRange(
                    new Genre
                    {
                        GenreName = "Personal Growth"
                    },
                    new Genre
                    {
                        GenreName = "Science Fiction"
                    },
                    new Genre
                    {
                        GenreName = "Romance"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
