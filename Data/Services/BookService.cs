using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myBooks.Data.Models;
using myBooks.Data.ViewModels;

namespace myBooks.Data.Services
{
  public class BookService
  {
    private AppDbContext _context;

    public BookService(AppDbContext context)
    {
      _context = context;
    }

    public void AddBook(BookViewModel book)
    {
      var _book = new Book()
      {
        Title = book.Title,
        Description = book.Description,
        IsRead = book.IsRead,
        DateRead = book.DateRead,
        Rating = book.Rating,
        Genre = book.Genre,
        Author = book.Author,
        CoverUrl = book.CoverUrl,
        DateAdded = DateTime.Now,
      };
      _context.Books.Add(_book);
      _context.SaveChanges();
    }
  }
}