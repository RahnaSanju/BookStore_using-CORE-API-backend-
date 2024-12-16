using Microsoft.AspNetCore.Mvc;
using BookStoreAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("BookAPI")]
    [ApiController]
    public class BookAPIController : ControllerBase
    {
        BookDB bookDB = new BookDB();


        // GET: api/<APIController>
        [HttpGet]
        [Route("GetAllBooks")]
        public List<Book> Get()
        {
            return bookDB.ViewAllBooks();
        }

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //GET api/<APIController>/5
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("GetBookWithId/{id}")]
        public Book Get(int id)
        {
            var getBook = bookDB.ViewAllBooks().Where(x => x.Book_Id == id).FirstOrDefault();
            return getBook;
        }

        //GET api/<APIController>/5
        //[HttpGet]
        //[Route("GetBooksSearch/{title?}/{auth?}/{price?}")]
        //public List<Book> Get(string? title = null, string? auth = null,double price = 0)
        //{
        //    var getBook = bookDB.SearchBooks(title,auth,price);
        //    return getBook;
        //}

        [HttpGet]
        [Route("GetBooksSearch")]
        public List<Book> Get(string? title = null, string? auth = null, double? price = null)
        {
            // Cleanse parameters
            title = !string.IsNullOrWhiteSpace(title) ? title.Trim() : null;
            auth = !string.IsNullOrWhiteSpace(auth) ? auth.Trim() : null;
            price = price > 0 ? price : null; // Ensure 0 means "no price filter"

            // Call the database method, passing only useful parameters
            var getBook = bookDB.SearchBooks(title, auth, price ?? 0);
            return getBook;
        }

        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<APIController>
        [HttpPost]
        [Route("PostCart")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<APIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
