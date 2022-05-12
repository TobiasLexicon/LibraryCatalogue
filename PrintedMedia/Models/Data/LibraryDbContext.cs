using System;
using Microsoft.EntityFrameworkCore;

namespace PrintedMedia.Models.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorBook>().HasKey(ab =>
                new {
                    ab.AuthorId,
                    ab.BookId
                });

            modelBuilder.Entity<AuthorBook>()
                .HasOne(ab => ab.Book)
                .WithMany(b => b.Authors)
                .HasForeignKey(ba => ba.AuthorId);

            modelBuilder.Entity<AuthorBook>()
                .HasOne(ab => ab.Author)
                .WithMany(a => a.BooksAuthored)
                .HasForeignKey(ab => ab.BookId);


            modelBuilder.Entity<Book>().HasData(

                new Book() { Id = 1, Title = "C# – Up & Running", Year = 2013, PublisherId = 4 },
                new Book() { Id = 2, Title = "Design Now", Year = 1983, PublisherId = 7 },
                new Book() { Id = 3, Title = "Event-Driven Development", Year = 2019, PublisherId = 4 },
                new Book() { Id = 4, Title = "Myths of management", Year = 2021, PublisherId = 6 },
                new Book() { Id = 5, Title = "Easy Performance", Year = 2019, PublisherId = 1 },
                new Book() { Id = 6, Title = "Continuous Breaks", Year = 2010, PublisherId = 1 }
                );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher() { Id = 1, Name = "Manning" },
                new Publisher() { Id = 2, Name = "Sage" },
                new Publisher() { Id = 3, Name = "Routledge" },
                new Publisher() { Id = 4, Name = "Wiley" },
                new Publisher() { Id = 5, Name = "O'Reilly" },
                new Publisher() { Id = 6, Name = "Harvard Business Press" },
                new Publisher() { Id = 7, Name = "Packt Publishing" }
                );

            modelBuilder.Entity<Author>().HasData(
                new Author() { Id = 1, Name = "Kurt Weill", YearBorn = 1900 },
                new Author() { Id = 2, Name = "Gillian Flynn", YearBorn = 1971 },
                new Author() { Id = 3, Name = "Donald Reinertsen", YearBorn = 1950 },
                new Author() { Id = 4, Name = "Yuri Lotman", YearBorn = 1922 }
                );

            modelBuilder.Entity<AuthorBook>().HasData(
                new AuthorBook() { AuthorId = 1, BookId = 3 },
                new AuthorBook() { AuthorId = 1, BookId = 4 },
                new AuthorBook() { AuthorId = 1, BookId = 6 }
                );
        }

    }
}
    