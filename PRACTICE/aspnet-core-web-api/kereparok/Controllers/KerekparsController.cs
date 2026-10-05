using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kereparok.Models;
using kereparok.DatabaseContext;

[Route("api/[controller]")]
[ApiController]
public class KerekparsController : ControllerBase
{
    private readonly DatabaseContext _context;
    public KerekparsController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpPost("task/{gyarto}/{ar}")]
    public async Task<ActionResult<Kerekpar>> GetFiltered(string? gyarto, int? ar)
    {
        if (gyarto == null || ar == null) return NoContent();

        var kerekparok = await _context.kerekparok
            .OrderByDescending(k => k.Gyarto)
            .Select(k => new
            {
                k.Gyarto,
                k.Tipus,
                k.Ar
            })
            .Where(k => k.Ar > ar && k.Gyarto.Contains(gyarto))
            .ToListAsync();


        return Ok(kerekparok);
    }
}
