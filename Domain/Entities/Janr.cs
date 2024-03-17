using static System.Reflection.Metadata.BlobBuilder;

namespace Domain.Entities;

public class Janr : BaseEntity
{
    public string Name { get; set; } = null!;
    public List<Book> Books { get; set; } = new();
}
