using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myBooks.Data.Models;

namespace myBooks.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      //defining composite key for BookAuthors
      modelBuilder.Entity<BookAuthors>()
        .HasKey(ba => new { ba.BookId, ba.AuthorId });

      //one-to-many BookAuthors-to-Book
      modelBuilder.Entity<BookAuthors>()
        .HasOne<Book>(ba => ba.Book)
        .WithMany(b => b.BookAuthors)
        .HasForeignKey(ba => ba.BookId);

      //one-to-many BookAuthors-to-Author
      modelBuilder.Entity<BookAuthors>()
        .HasOne<Author>(ba => ba.Author)
        .WithMany(a => a.BookAuthors)
        .HasForeignKey(ba => ba.AuthorId);
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publisher { get; set; }
    public DbSet<Author> Author { get; set; }

    public DbSet<BookAuthors> BookAuthors { get; set; }
  }
}