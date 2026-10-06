using Microsoft.AspNetCore.Mvc;
using filmek.Models;
using filmek.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

[Route("api/[controller]")]
[ApiController]
public class FilmekController : ControllerBase
{
    private readonly DatabaseContext _context;
    public FilmekController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpPost("Feladat/{studio}/{hossz}")]
    public async Task<ActionResult<Filmek>> PostFilmek(string? studio, int? hossz)
    {
        if (studio == null || hossz == null) return NoContent();

        var filmek = await _context.filmek
            .OrderByDescending(f => f.Bevetel)
            .Select(f => new
            {
                f.Studio,
                f.Mufaj,
                f.Bevetel,
                f.Hossz,
            })
            .Where(f => f.Studio.ToLower().Contains(studio.ToLower()) && f.Hossz > hossz)
            .ToListAsync();

        return Ok(
            filmek
        );
    }
}
