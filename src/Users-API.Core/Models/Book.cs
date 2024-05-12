namespace Users_API.Core.Models;

public class Book
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Author { get; set; }
    public int? Pages { get; set; }
    public string[]? Tags { get; set; }
}