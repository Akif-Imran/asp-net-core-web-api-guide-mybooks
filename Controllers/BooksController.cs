using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using myBooks.Data.Services;
using myBooks.Data.ViewModels;

namespace myBooks.Controllers
{
  [Route(template: "api/[controller]")]
  [ApiController]
  public class BooksController : ControllerBase
  {
    private readonly BookService _bookService;

    public BooksController(BookService bookService)
    {
      _bookService = bookService;
    }

    [HttpGet(template: "get-book-by-id")]
    public IActionResult GetBook([FromQuery] int id)
    {
      var book = _bookService.GetBook(id);
      if (book == null) return NoContent();
      return Ok(book);
    }

    [HttpGet(template: "get-all-books")]
    public IActionResult GetAllBooks()
    {
      var books = _bookService.GetAllBooks();
      if (books.Count == 0) return NoContent();
      return Ok(books);
    }

    [HttpPost(template: "add-book")]
    public IActionResult AddBook([FromBody] BookViewModel book)
    {
      _bookService.AddBook(book: book);
      return Ok();
    }

    [HttpPut(template: "update-book-by-id")]
    public IActionResult UpdateBookById([FromQuery, BindRequired] int id, [FromBody] BookViewModel book)
    {
      var updatedBook = _bookService.UpdateBookById(id, book);
      if (updatedBook == null) return NoContent();
      return Ok(updatedBook);
    }

    [HttpDelete(template: "delete-book-by-id")]
    public IActionResult DeleteBookById([FromQuery] int id)
    {
      bool result = _bookService.DeleteBookById(id);
      return result ? Ok(new { message = "Book Deleted" }) : NoContent();
    }
  }
}