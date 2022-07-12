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
    private readonly AppDbContext _context;

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

    public List<Book> GetAllBooks()
    {
      return _context.Books.ToList();
    }

    public Book GetBook(int id)
    {
      return _context.Books.Find(id);
    }

    public Book UpdateBookById(int id, BookViewModel newBookRecord)
    {
      var book = _context.Books.Find(id);
      if (book == null) return null;
      book.Title = newBookRecord.Title;
      book.Description = newBookRecord.Description;
      book.IsRead = newBookRecord.IsRead;
      book.DateRead = newBookRecord.DateRead;
      book.Rating = newBookRecord.Rating;
      book.Genre = newBookRecord.Genre;
      book.Author = newBookRecord.Author;
      book.CoverUrl = newBookRecord.CoverUrl;
      _context.SaveChanges();
      return book;
    }

    public bool DeleteBookById(int id)
    {
      var book = _context.Books.Find(id);
      if (book == null) return false;
      _context.Books.Remove(book);
      _context.SaveChanges();
      return true;
    }
  }
}