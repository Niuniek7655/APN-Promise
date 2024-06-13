using API.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrdersController(IOrderService bookService)
    {
        _orderService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] int pageNumber = 1, int pageSize = 10)
    {
        if (pageNumber < 1)
        {
            return BadRequest("The page number cannot be less than 1");
        }
        if (pageSize <= 0) 
        {
            return BadRequest("The page size cannot be less than or equal to 0");
        }

        var result = await _orderService.GetOrders(pageNumber, pageSize);
        return Ok(result);
    }
}
