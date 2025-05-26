public class Category
{
    public int CategoryId { get; set; }
    public required string CategoryName { get; set; } // Sử dụng required
    public ICollection<Book>? Books { get; set; } // Nullable
}