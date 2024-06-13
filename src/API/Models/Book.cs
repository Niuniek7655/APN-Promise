﻿namespace Core.Models;

public class Book
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public long Bookstand { get; set; }
    public long Shelf { get; set; }
    public IEnumerable<Author> Authors { get; set; } = Enumerable.Empty<Author>();
}
