using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    public record Book(int id, string title, string author);

    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        Book[] Books = [
            new ( 1, "Project Hail Mary", "Andy Weir"),
            new ( 2, "Harry Potter and the Philosopher's Stone", "She who will not be named"),
        ];

        // GET: api/<BookController>
        [HttpGet]
        public Book[] Get()
        {
            return Books;
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var bookIWant = Books.FirstOrDefault(b => b.id == id);

            if (bookIWant == null)
            {
                return new NotFoundResult();
            }

            return Ok(bookIWant);
        }

        //// POST api/<BookController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<BookController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<BookController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
