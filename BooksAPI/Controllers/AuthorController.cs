using Application.Common;
using Application.DTOs.AuthorDTOs;
using Application.DTOs.JanrDTOs;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController(IAuthorService authorService)
    : ControllerBase
{
    private readonly IAuthorService _authorService = authorService;
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _authorService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var result = await _authorService.GetByIdAsync(id);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddAuthorDto dto)
    {
        try
        {
            await _authorService.CreateAsync(dto);
            return Ok();
        }
        catch (BookException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(AuthorDto dto)
    {
        try
        {
            await _authorService.UpdateAsync(dto);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (BookException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _authorService.DeleteAsync(id);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}
