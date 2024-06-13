using API.Abstractions;
using Core.Models;

namespace Infrastructure.Repositories;

public class InMemeoryBookRepository : IBookRepository
{
    //Not thread-safe, use Concurrent collections
    private IEnumerable<Book> _books = new List<Book>()
    {
        new Book()
        {
            Id = 1,
            Title = "Test1",
            Price = 100,
            Bookstand = 1,
            Shelf = 1,
            Authors = new List<Author>()
            {
                new()
                {
                    FirstName = "Test1",
                    LastName = "Test1",
                }
            }
        },
        new Book()
        {
            Id = 2,
            Title = "Test2",
            Price = 150,
            Bookstand = 2,
            Shelf = 2,
            Authors = new List<Author>()
            {
                new()
                {
                    FirstName = "Test2",
                    LastName = "Test2",
                }
            }
        },
        new Book()
        {
            Id = 3,
            Title = "Test3",
            Price = 200,
            Bookstand = 3,
            Shelf = 3,
            Authors = new List<Author>()
            {
                new()
                {
                    FirstName = "Test3",
                    LastName = "Test3",
                }
            }
        }
    };

    public Task<IEnumerable<Book>> GetBooks()
    {
        return Task.FromResult(_books);
    }

    public Task CreateBook(Book book)
    {
        _books = AddElement<Book>(_books, book);
        return Task.CompletedTask;
    }

    private static IEnumerable<T> AddElement<T>(IEnumerable<T> source, T element)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source), "Source collection cannot be null.");

        return source.Concat([element]);
    }
}
