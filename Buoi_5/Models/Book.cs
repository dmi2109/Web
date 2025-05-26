public class Book
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; } // Nullable
    public string? Image { get; set; } // Nullable
    public int CategoryId { get; set; }
    public Category? Category { get; set; } // Nullable
}