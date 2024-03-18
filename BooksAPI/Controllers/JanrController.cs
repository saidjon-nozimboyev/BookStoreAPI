using Application.Common;
using Application.DTOs.JanrDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JanrController(IJanrService janrService)
        : ControllerBase
    {
        private readonly IJanrService _janrService = janrService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _janrService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _janrService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddJanrDto dto)
        {
            try
            {
                await _janrService.CreateAsync(dto);
                return Ok();
            }
            catch (BookException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(JanrDto dto)
        {
            try
            {
                await _janrService.UpdateAsync(dto);
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
                await _janrService.DeleteAsync(id);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
