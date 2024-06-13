using Lib.Abstractions;
using Lib.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly IBooksControllerConsumer _booksControllerConsumer;
    private readonly IOrdersControllerConsumer _ordersControllerConsumer;
    public TestController(
        IBooksControllerConsumer booksControllerConsumer,
        IOrdersControllerConsumer ordersControllerConsumer)
    {
        _booksControllerConsumer = booksControllerConsumer;
        _ordersControllerConsumer = ordersControllerConsumer;
    }

    [HttpGet("book")]
    public async Task<IActionResult> GetBooks()
    {
        var result = await _booksControllerConsumer.GetBooks();
        return Ok(result);
    }

    [HttpPost("book")]
    public async Task<IActionResult> CreateBook(BookDto book)
    {
        await _booksControllerConsumer.CreateBook(book);
        return Ok();
    }

    [HttpGet("order")]
    public async Task<IActionResult> GetOrders([FromQuery] int pageNumber = 1, int pageSize = 10)
    {
        var result = await _ordersControllerConsumer.GetOrders(pageNumber, pageSize);
        return Ok(result);
    }
}
