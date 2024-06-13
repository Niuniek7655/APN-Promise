using API.Abstractions;
using API.Dtos;

namespace Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<BookDto>> GetBooks()
    {
        var books = await _bookRepository.GetBooks();
        var result = books.Select(x => x.AsDto());
        return result;
    }

    public async Task CreateBook(BookDto dto)
    {
        var book = dto.AsModel();
        await _bookRepository.CreateBook(book);
    }
}
