using Core.Models;

namespace API.Abstractions;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooks();
    Task CreateBook(Book book);
}
