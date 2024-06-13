using Lib.Abstractions;
using Lib.Dtos;

namespace Lib.Consumers;

internal class BooksControllerConsumer : IBooksControllerConsumer
{
    private readonly IApiService _apiService;
    public BooksControllerConsumer(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IEnumerable<BookDto>> GetBooks()
    {
        return await _apiService.GetBooks();
    }

    public async Task CreateBook(BookDto dto)
    {
        await _apiService.CreateBook(dto);
    }
}
