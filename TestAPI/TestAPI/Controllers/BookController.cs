using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        List<Book> allBooks = new List<Book>();

        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger)
        {
            allBooks.Add(new Book() { BookId = 1, Author = "A", ShortDescription = "Book of Author A", Title = "Story Book 1" });
            allBooks.Add(new Book() { BookId = 2, Author = "B", ShortDescription = "Book of Author B", Title = "Story Book 2" });
            allBooks.Add(new Book() { BookId = 3, Author = "C", ShortDescription = "Book of Author C", Title = "Story Book 3" });
            _logger = logger;
        }

        [HttpGet]
        [Route("/books")]
        public IEnumerable<Book> Get()
        {
            return allBooks.ToArray();
        }
        [HttpGet]
        [Route("/books/{id}")]
        public Book Get(int id)
        {
            var book = allBooks.Where(x => x.BookId == id).FirstOrDefault();
            if(book != null)
                return book;
            else
            {
                return null;
            }

        }
    }
}
