using Lib.Dtos;

namespace Lib.Abstractions;

public interface IBooksControllerConsumer
{
    public Task<IEnumerable<BookDto>> GetBooks();
    public Task CreateBook(BookDto dto);
}
