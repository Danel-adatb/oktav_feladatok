using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Config.DB;

[Route("api/[controller]")]
[ApiController]
public class ManufacturersController : ControllerBase
{
    private readonly DatabaseContext _context;
    public ManufacturersController(DatabaseContext context)
    {
        _context = context;
    }

    // GET: api/Manufacturer
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturer()
    {
        return await _context.manufacturers.ToListAsync();
    }

    // GET: api/Manufacturer/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Manufacturer>> GetManufacturer(int id)
    {
        var manufacturer = await _context.manufacturers.FindAsync(id);

        if (manufacturer == null)
        {
            return NotFound();
        }

        return manufacturer;
    }

    // POST: api/Manufacturer
    [HttpPost]
    public async Task<ActionResult<ManufacturerDTO>> PostManufacturer(ManufacturerDTO dto)
    {
        var manufacturer = new Manufacturer
        {
            Name = dto.Name,
            Founded = dto.Founded,
            Nationality = dto.Nationality,
            Subsidiary = dto.Subsidiary,

        };

        _context.manufacturers.Add(manufacturer);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetManufacturer", new { id = manufacturer.Id }, manufacturer);
    }

    // PUT: api/Manufacturer/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutManufacturer(int? id, ManufacturerDTO dto)
    {
        var manufacturer = new Manufacturer
        {
            Name = dto.Name,
            Founded = dto.Founded,
            Nationality = dto.Nationality,
            Subsidiary = dto.Subsidiary,

        };

        _context.Entry(manufacturer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ManufacturerExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Manufacturer/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteManufacturer(int? id)
    {
        var manufacturer = await _context.manufacturers.FindAsync(id);
        if (manufacturer == null)
        {
            return NotFound();
        }

        _context.manufacturers.Remove(manufacturer);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ManufacturerExists(int? id)
    {
        return _context.manufacturers.Any(e => e.Id == id);
    }
}
