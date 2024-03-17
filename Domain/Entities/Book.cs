namespace Domain.Entities;

public class Book : BaseEntity
{
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; } = new Author();
    public int JanrId { get; set; }
    public Janr Janr { get; set; } = new Janr();
}
