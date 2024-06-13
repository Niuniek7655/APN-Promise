using API.Abstractions;
using API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var result = await _bookService.GetBooks();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(BookDto book)
    {
        await _bookService.CreateBook(book);
        return Ok();
    }
}
