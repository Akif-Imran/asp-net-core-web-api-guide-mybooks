using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using myBooks.Data.Models;

namespace myBooks.Data
{
  public class AppDbInitializer
  {
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
      using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
        if (!context.Books.Any())
        {
          context.Books.AddRange(new Book()
            {
              Title = "1st Book Title",
              Description = "1st Book Description",
              IsRead = true,
              DateRead = DateTime.Now.AddDays(-10),
              Rating = 4,
              Genre = "Biography",
              Author = "First Author",
              CoverUrl = "https:www.example.com/.....",
              DateAdded = DateTime.Now
            },
            new Book()
            {
              Title = "2nd Book Title",
              Description = "2nd Book Description",
              IsRead = false,
              DateRead = DateTime.Now.AddDays(-10),
              Genre = "Biography",
              Author = "First Author",
              CoverUrl = "https:www.example.com/.....",
              DateAdded = DateTime.Now
            }
          );
          context.SaveChanges();
        }
      }
    }
  }
}