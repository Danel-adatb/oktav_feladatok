using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Config.DB;

[Route("api/[controller]")]
[ApiController]
public class ToolsController : ControllerBase
{
    private readonly DatabaseContext _context;
    public ToolsController(DatabaseContext context)
    {
        _context = context;
    }

    // GET: api/Tool
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tool>>> GetTool()
    {
        return await _context.tools.ToListAsync();
    }

    // GET: api/Tool/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Tool>> GetTool(int id)
    {
        var tool = await _context.tools.FindAsync(id);

        if (tool == null)
        {
            return NotFound();
        }

        return tool;
    }

    // PUT: api/Tool/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTool(int? id, ToolDTO dto)
    {
        
        var tool = await _context.tools.FirstOrDefaultAsync(x => x.Id == id);

        if (tool == null) return NoContent();

        tool.Serial = dto.Serial;
        tool.Manufacturer = dto.Manufacturer;
        tool.Type = dto.Type;
        tool.Price = dto.Price;
        tool.Source = dto.Source;
        tool.RentPrice = dto.RentPrice;

        _context.tools.Update(tool);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ToolExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return Ok(new
        {
            message = "Sikeres frissítés!",
            result = tool
        });
    }

    // POST: api/Tool
    [HttpPost]
    public async Task<ActionResult<Tool>> PostTool(ToolDTO dto)
    {
        var tool = new Tool
        {
            Serial = dto.Serial,
            Manufacturer = dto.Manufacturer,
            Type = dto.Type,
            Price = dto.Price,
            Source = dto.Source,
            RentPrice = dto.RentPrice,
        };

        _context.tools.Add(tool);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTool", new { id = tool.Id }, tool);
    }

    // DELETE: api/Tool/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTool(int? id)
    {
        var tool = await _context.tools.FindAsync(id);
        if (tool == null)
        {
            return NotFound();
        }

        _context.tools.Remove(tool);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ToolExists(int? id)
    {
        return _context.tools.Any(e => e.Id == id);
    }

    //Feladatok (backend)
    [HttpPost("task/{tool}/{price}")]
    public async Task<ActionResult<Tool>> PostQuery(string? manufacturer, int? price)
    {
        if((manufacturer == null || manufacturer == "") || (price == null || price <= 0))
        {
            return NoContent();
        }

        var tools = await _context.tools
        .Join(
            _context.manufacturers,
            tool => tool.Manufacturer,
            manufacturer => manufacturer.Name,
            (tool, manufacturer) => new {
                tool.Id,
                tool.Manufacturer,
                tool.Type,
                tool.Price
            })
        .OrderByDescending(t => t.Price)
        .Select(t => new
        {
            t.Id,
            t.Manufacturer,
            t.Price
        })
        .Where(t =>  t.Manufacturer.Contains(manufacturer) && t.Price >= price)
        .ToListAsync();

        return Ok(tools);
    }
}
