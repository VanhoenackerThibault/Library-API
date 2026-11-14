using Library.Models.Core;
using Library.Models.Dto;
using Library.Models.Mappers;
using Library.Models.Paging;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IBookService bookService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PagedResponse<Book>>> GetBooks([FromQuery] Query query)
        {
            List<Book> books = await bookService.GetBooksAsync();

            PagedResponse<Book> response = books.ToPagedResponse(query.PageSize, query.Page);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBook([FromRoute] int id)
        {

            Book? book = await bookService.GetBookByIdAsync(id);

            if (book is null)
            {
                return BadRequest(new { Mesage = "No book exists with that id!" });
            }

            return Ok(book.ToDto());
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook([FromBody] BookDto dto)
        {
            Book book = await bookService.CreateBookAsync(dto);

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book.ToDto());
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Book>> UpdateBook([FromRoute] int id, [FromBody] BookDto dto)
        {
            try
            {
                Book book = await bookService.UpdateBookAsync(id, dto);

                return Ok(book.ToDto());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mesage = $"A problem has accured with message: {ex.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBook([FromRoute] int id)
        {
            try
            {
                await bookService.DeleteBookAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mesage = $"A problem has accured with message: {ex.Message}" });
            }
        }
    }
}
