using API.Dtos;

namespace API.Abstractions;

public interface IBookService
{
    public Task<IEnumerable<BookDto>> GetBooks();
    public Task CreateBook(BookDto dto);
}
