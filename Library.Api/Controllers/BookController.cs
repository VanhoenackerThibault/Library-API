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
                return NotFound(new { Message = "No book exists with that id!" });
            }

            return Ok(book.ToDto());
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook([FromBody] BookDto dto)
        {
            Book? book = await bookService.CreateBookAsync(dto);

            if (book is null)
            {
                return NotFound(new { Message = $"No author found with that id!" });
            }

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book.ToDto());
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Book>> UpdateBook([FromRoute] int id, [FromBody] BookDto dto)
        {
            try
            {
                Book? book = await bookService.UpdateBookAsync(id, dto);

                if (book is null)
                {
                    return NotFound(new { Message = $"No book/author found with that id!" });
                }

                return Ok(book.ToDto());
            }
            catch (Exception)
            {
                return BadRequest(new { Message = $"A problem has accrued" });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBook([FromRoute] int id)
        {
            try
            {
                bool? state = await bookService.DeleteBookAsync(id);

                if (state is null)
                {
                    return NotFound(new { Message = $"No book found with that id!" });
                }

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest(new { Message = $"A problem has accrued" });
            }
        }
    }
}
