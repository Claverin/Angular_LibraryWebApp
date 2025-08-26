using LibraryWebApp.Models.DTO;
using LibraryWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _svc;
        public GenreController(IGenreService svc) { _svc = svc; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetAll(CancellationToken ct)
            => Ok(await _svc.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GenreDto>> Get(int id, CancellationToken ct)
        {
            var item = await _svc.GetAsync(id, ct);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<GenreDto>> Create([FromBody] GenreDto dto, CancellationToken ct)
            => Ok(await _svc.CreateAsync(dto, ct));

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<GenreDto>> Update(int id, [FromBody] GenreDto dto, CancellationToken ct)
        {
            var updated = await _svc.UpdateAsync(id, dto, ct);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
            => await _svc.DeleteAsync(id, ct) ? NoContent() : NotFound();
    }
}