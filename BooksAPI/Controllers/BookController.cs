using Application.Common;
using Application.DTOs.AuthorDTOs;
using Application.DTOs.BookDTOs;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController(IBookService bookService)
    : ControllerBase
{
    private readonly IBookService _bookService = bookService;
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _bookService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var result = await _bookService.GetByIdAsync(id);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddBookDto dto)
    {
        try
        {
            await _bookService.CreateAsync(dto);
            return Ok();
        }
        catch (BookException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(BookDto dto)
    {
        try
        {
            await _bookService.UpdateAsync(dto);
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
            await _bookService.DeleteAsync(id);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}
