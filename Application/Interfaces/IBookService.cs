using Application.DTOs.BookDTOs;

namespace Application.Interfaces;

public interface IBookService
{
    Task<List<BookDto>> GetAllAsync();
    Task<BookDto> GetByIdAsync(int id);
    Task CreateAsync(AddBookDto addBookDto);
    Task UpdateAsync(BookDto updBookDto);
    Task DeleteAsync(int id);
}
