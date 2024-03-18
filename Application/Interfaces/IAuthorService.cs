

using Application.DTOs.AuthorDTOs;

namespace Application.Interfaces;

public interface IAuthorService
{
    Task<List<AuthorDto>> GetAllAsync();
    Task<AuthorDto> GetByIdAsync(int id);
    Task CreateAsync(AddAuthorDto addAuthorDto);
    Task UpdateAsync(AuthorDto updAuthorDto);
    Task DeleteAsync(int id);
}
