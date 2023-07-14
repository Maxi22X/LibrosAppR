using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibrosApp.Models
{
    public class LibrosContext : DbContext
    {
        public LibrosContext(DbContextOptions<LibrosContext> options)
            : base(options)
        { }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, Name = "Antoine de Saint-Exupéry", Country = "Francia" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "El principito", PublicationYear = "1943", AuthorId = 1 },
                new Book { BookId = 2, Title = "Tierra de hombres", PublicationYear = "1939", AuthorId = 1 },
                new Book { BookId = 3, Title = "Vuelo nocturno", PublicationYear = "1931", AuthorId = 1 },
                new Book { BookId = 4, Title = "The Wisdom of the Sands", PublicationYear = "1948", AuthorId = 1 },
                new Book { BookId = 5, Title = "Piloto de guerra", PublicationYear = "1942", AuthorId = 1 },
                new Book { BookId = 6, Title = "Carta a un rehén", PublicationYear = "1943", AuthorId = 1 }
            );

            base.OnModelCreating(modelBuilder);
        }






    }
}
