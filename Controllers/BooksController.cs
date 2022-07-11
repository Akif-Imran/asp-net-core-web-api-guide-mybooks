using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    [HttpPost(template: "add-book")]
    public IActionResult AddBook([FromBody] BookViewModel book)
    {
      _bookService.AddBook(book: book);
      return Ok();
    }
  }
}