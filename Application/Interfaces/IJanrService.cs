using Application.DTOs.JanrDTOs;

namespace Application.Interfaces;

public interface IJanrService
{
    Task<List<JanrDto>> GetAllAsync();
    Task<JanrDto> GetByIdAsync(int id);
    Task CreateAsync(AddJanrDto addJanrDto);
    Task UpdateAsync(JanrDto updJanrDto);
    Task DeleteAsync(int id);
}
