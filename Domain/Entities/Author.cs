using static System.Reflection.Metadata.BlobBuilder;

namespace Domain.Entities;

public class Author : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public List<Book> Books { get; set; } = new();
}
