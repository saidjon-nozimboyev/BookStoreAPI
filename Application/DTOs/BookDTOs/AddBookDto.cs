namespace Application.DTOs.BookDTOs;

public class AddBookDto
{
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public int AuthorId { get; set; }
    public int JanrId { get; set; } 
}
