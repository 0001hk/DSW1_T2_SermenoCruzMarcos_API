using Microsoft.AspNetCore.Mvc;
using DSW1_T2_SermenoCruzMarcos.Application.Services.Interfaces;
using DSW1_T2_SermenoCruzMarcos.Application.DTOs;
using System.Net;
using DSW1_T2_SermenoCruzMarcos.Application.DTOs.Book; 
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BookDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        var books = await _bookService.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BookDto), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> Create([FromBody] CreateBookDto dto)
    {
        var book = await _bookService.CreateBookAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BookDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        if (book == null) return NotFound();
        return Ok(book);
    }
    
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Update([FromBody] UpdateBookDto dto)
    {
        try
        {
             await _bookService.UpdateBookAsync(dto);
             return NoContent(); 
        }
        catch (Exception) 
        {
            return NotFound(); 
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
         try
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
        catch (Exception) 
        {
            return NotFound();
        }
    }
}