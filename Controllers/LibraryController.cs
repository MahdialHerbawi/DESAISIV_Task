using DESAISIV.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DESAISIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public LibraryController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("Add New Book")]
        public async Task<ActionResult<List<Book>>> AddBook(Book book)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            _dataContext.Books.Add(book);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Books.ToListAsync());
        }


        [HttpDelete]
        [Route("Delete the book")]

        public async Task<ActionResult<Book>> DeleteBook(int Id)
        {
           
            var book = await _dataContext.Books.FindAsync(Id);

            
            if (book == null)
            {
                return NotFound("Book not found.");
            }

           
            _dataContext.Books.Remove(book);

           
            await _dataContext.SaveChangesAsync();

           
            return Ok(book);


        }

        [HttpPut("{id}")]
        
        public async Task<ActionResult<Book>> EditBook(int id, Book updatedBook)
        {
           
            var book = await _dataContext.Books.FindAsync(id);

           
            if (book == null)
            {
                return NotFound("Book not found.");
            }

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.PublicationYear = updatedBook.PublicationYear;
            await _dataContext.SaveChangesAsync();

            return Ok(book);
        }



        [HttpGet]
        [Route("Show All The Books")]
        public async Task<ActionResult<List<Book>>> ShowBooks()
        {
            return Ok(await _dataContext.Books.ToListAsync());
        }

        [HttpGet("{Id}")]
        
        public async Task<ActionResult<Book>> GetById(int Id)
        {
            var character = await _dataContext.Books.FindAsync(Id);
            if (character == null)
            {
                return BadRequest("id not found");
            }

            return Ok(character);


        }



        //test test

    }
}
