using Library.Models.Core;
using Library.Models.Mappers;
using Library.Models.Paging;
using Library.Services.Interfaces;
using Library.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController(IAuthorService authorService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PagedResponse<Author>>> GetAuthors([FromQuery] Query query)
        {
            List<Author> authors = await authorService.GetAuthorsAsync();

            PagedResponse<Author> response = authors.ToPagedResponse(query.PageSize, query.Page);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Author>> GetBook([FromRoute] int id)
        {

            Author? author = await authorService.GetAuthorByIdAsync(id);

            if (author is null)
            {
                return BadRequest(new { Mesage = "No author exists with that id!" });
            }

            return Ok(author.ToDto());
        }
    }
}
