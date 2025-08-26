using LibraryWebApp.Models.DTO;
using LibraryWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _svc;
        public AuthorController(IAuthorService svc) { _svc = svc; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAll(CancellationToken ct)
            => Ok(await _svc.GetAllAsync(ct));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AuthorDto>> Get(int id, CancellationToken ct)
        {
            var item = await _svc.GetAsync(id, ct);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Create([FromBody] AuthorDto dto, CancellationToken ct)
            => Ok(await _svc.CreateAsync(dto, ct));

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<AuthorDto>> Update(int id, [FromBody] AuthorDto dto, CancellationToken ct)
        {
            var updated = await _svc.UpdateAsync(id, dto, ct);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
            => await _svc.DeleteAsync(id, ct) ? NoContent() : NotFound();
    }
}