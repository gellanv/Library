using Library.Data.Models;

namespace Library.Data
{
    public static class MockData
    {
        public static void AddCustomerData(WebApplication app)
        {
            var db = app.Services.CreateScope().ServiceProvider.GetService<ApiDBContext>();

            Book book1 = new Book()
            {
                Id = 1,
                Author = "Author-111",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Cover = "byte64",
                Genre = "genre-1",
                Title = "Title-1"
            };

            db.Books.Add(book1);

            Review review1 = new Review()
            {
                Id = 1,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book1.Id,
                Reviewer = "Reviewer-1"

            };
            Review review2 = new Review()
            {
                Id = 2,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book1.Id,
                Reviewer = "Reviewer-2"
            };
            db.Reviews.Add(review1);
            db.Reviews.Add(review2);
            Rating rating1 = new() { Id = 1, BookId = book1.Id, Score = 4.5M };
            Rating rating2 = new() { Id = 2, BookId = book1.Id, Score = 4.8M };
            db.Ratings.Add(rating1);
            db.Ratings.Add(rating2);

            Book book2 = new Book()
            {
                Id = 2,
                Author = "Author-1",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Cover = "byte64",
                Genre = "genre-2",
                Title = "Title-2"
            };
            db.Books.Add(book2);
            Review review3 = new Review()
            {
                Id = 3,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book2.Id,
                Reviewer = "Reviewer-3"

            };
            Review review4 = new Review()
            {
                Id = 4,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book2.Id,
                Reviewer = "Reviewer-4"
            };
            db.Reviews.Add(review3);
            db.Reviews.Add(review4);
            Rating rating3 = new() { Id = 3, BookId = book2.Id, Score = 4.1M };
            Rating rating4 = new() { Id = 4, BookId = book2.Id, Score = 4.9M };
            db.Ratings.Add(rating3);
            db.Ratings.Add(rating4);

            Book book3 = new Book()
            {
                Id = 3,
                Author = "Author-3",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Cover = "byte64",
                Genre = "genre-1",
                Title = "Title-3"
            };
            db.Books.Add(book3);
            Review review5 = new Review()
            {
                Id = 5,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book3.Id,
                Reviewer = "Reviewer-5"

            };
            Review review6 = new Review()
            {
                Id = 6,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book3.Id,
                Reviewer = "Reviewer-6"
            };
            db.Reviews.Add(review5);
            db.Reviews.Add(review6);
            Rating rating5 = new() { Id = 5, BookId = book3.Id, Score = 4M };
            Rating rating6 = new() { Id = 6, BookId = book3.Id, Score = 4.9M };
            db.Ratings.Add(rating5);
            db.Ratings.Add(rating6);

            Book book4 = new Book()
            {
                Id = 4,
                Author = "Author-4",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Cover = "byte64",
                Genre = "genre-2",
                Title = "Title-4"
            };
            db.Books.Add(book4);
            Review review7 = new Review()
            {
                Id = 7,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book4.Id,
                Reviewer = "Reviewer-7"

            };
            Review review8 = new Review()
            {
                Id = 8,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book4.Id,
                Reviewer = "Reviewer-8"
            };
            db.Reviews.Add(review7);
            db.Reviews.Add(review8);
            Rating rating7 = new() { Id = 7, BookId = book4.Id, Score = 3.8M };
            Rating rating8 = new() { Id = 8, BookId = book4.Id, Score = 4.7M };
            db.Ratings.Add(rating7);
            db.Ratings.Add(rating8);

            Book book5 = new Book()
            {
                Id = 5,
                Author = "Author-5",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Cover = "byte64",
                Genre = "genre-1",
                Title = "Title-5"
            };
            db.Books.Add(book5);
            Review review9 = new Review()
            {
                Id = 9,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book5.Id,
                Reviewer = "Reviewer-9"

            };
            Review review10 = new Review()
            {
                Id = 10,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book5.Id,
                Reviewer = "Reviewer-10"
            };
            db.Reviews.Add(review9);
            db.Reviews.Add(review10);
            Rating rating9 = new() { Id = 9, BookId = book5.Id, Score = 3.2M };
            Rating rating10 = new() { Id = 10, BookId = book5.Id, Score = 4.7M };
            db.Ratings.Add(rating9);
            db.Ratings.Add(rating10);

            Book book6 = new Book()
            {
                Id = 6,
                Author = "Author-6",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Cover = "byte64",
                Genre = "genre-2",
                Title = "Title-6"
            };
            db.Books.Add(book6);
            Review review11 = new Review()
            {
                Id = 11,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book6.Id,
                Reviewer = "Reviewer-11"
            };
            Review review12 = new Review()
            {
                Id = 12,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book6.Id,
                Reviewer = "Reviewer-12"
            };
            db.Reviews.Add(review11);
            db.Reviews.Add(review12);
            Rating rating11 = new() { Id = 11, BookId = book6.Id, Score = 3.2M };
            Rating rating12 = new() { Id = 12, BookId = book6.Id, Score = 4.7M };
            db.Ratings.Add(rating11);
            db.Ratings.Add(rating12);

            Book book7 = new Book()
            {
                Id = 7,
                Author = "Author-7",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Cover = "byte64",
                Genre = "genre-1",
                Title = "Title-7"
            };
            db.Books.Add(book7);
            Review review13 = new Review()
            {
                Id = 13,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book7.Id,
                Reviewer = "Reviewer-13"
            };
            Review review14 = new Review()
            {
                Id = 14,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book7.Id,
                Reviewer = "Reviewer-14"
            };
            db.Reviews.Add(review13);
            db.Reviews.Add(review14);
            Rating rating13 = new() { Id = 13, BookId = book7.Id, Score = 4.2M };
            Rating rating14 = new() { Id = 14, BookId = book7.Id, Score = 4.3M };
            db.Ratings.Add(rating13);
            db.Ratings.Add(rating14);

            Book book8 = new Book()
            {
                Id = 8,
                Author = "Author-8",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Cover = "byte64",
                Genre = "genre-2",
                Title = "Title-8"
            };
            db.Books.Add(book8);
            Review review15 = new Review()
            {
                Id = 15,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book8.Id,
                Reviewer = "Reviewer-15"
            };
            Review review16 = new Review()
            {
                Id = 16,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book8.Id,
                Reviewer = "Reviewer-16"
            };
            db.Reviews.Add(review15);
            db.Reviews.Add(review16);
            Rating rating15 = new() { Id = 15, BookId = book8.Id, Score = 4.6M };
            Rating rating16 = new() { Id = 16, BookId = book8.Id, Score = 3.2M };
            db.Ratings.Add(rating15);
            db.Ratings.Add(rating16);

            Book book9 = new Book()
            {
                Id = 9,
                Author = "Author-9",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Cover = "byte64",
                Genre = "genre-1",
                Title = "Title-9"
            };
            db.Books.Add(book9);
            Review review17 = new Review()
            {
                Id = 17,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book9.Id,
                Reviewer = "Reviewer-17"
            };
            Review review18 = new Review()
            {
                Id = 18,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book9.Id,
                Reviewer = "Reviewer-18"
            };
            db.Reviews.Add(review17);
            db.Reviews.Add(review18);
            Rating rating17 = new() { Id = 17, BookId = book9.Id, Score = 4.7M };
            Rating rating18 = new() { Id = 18, BookId = book9.Id, Score = 3.2M };
            db.Ratings.Add(rating17);
            db.Ratings.Add(rating18);

            Book book10 = new Book()
            {
                Id = 10,
                Author = "Author-10",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Cover = "byte64",
                Genre = "genre-2",
                Title = "Title-10"
            };
            db.Books.Add(book10);
            Review review19 = new Review()
            {
                Id = 19,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book10.Id,
                Reviewer = "Reviewer-19"
            };
            Review review20 = new Review()
            {
                Id = 20,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                BookId = book10.Id,
                Reviewer = "Reviewer-20"
            };
            db.Reviews.Add(review19);
            db.Reviews.Add(review20);
            Rating rating19 = new() { Id = 19, BookId = book10.Id, Score = 4.8M };
            Rating rating20 = new() { Id = 20, BookId = book10.Id, Score = 3.3M };
            db.Ratings.Add(rating19);
            db.Ratings.Add(rating20);

            db.SaveChanges();
        }
    }
}
