using System.Collections.Generic;

namespace myBooks.Data.Models
{
  public class Author
  {
    public int Id { get; set; }
    public string FullName { get; set; }

    //NavigationProperties
    public IList<BookAuthors> BookAuthors { get; set; }
  }
}
