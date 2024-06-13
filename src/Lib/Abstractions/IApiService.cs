using Lib.Dtos;
using Refit;

namespace Lib.Abstractions;

[Headers("Content-Type: application/json")]
internal interface IApiService
{
    [Get("/api/books")]
    Task<IEnumerable<BookDto>> GetBooks();
    [Post("/api/books")]
    Task CreateBook(BookDto dto);
    [Get("/api/orders")]
    Task<IEnumerable<OrderDto>> GetOrders([Query] int pageNumber, int pageSize);
}
