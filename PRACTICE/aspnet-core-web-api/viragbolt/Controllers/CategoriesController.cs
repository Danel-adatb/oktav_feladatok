using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using viragbolt.Models;
using viragbolt.Config;
using viragbolt.Models.DTO;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly DatabaseContext _context;
    public CategoriesController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categories>>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    // GET: api/Categories/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Categories>> GetCategories(int id)
    {
        var categories = await _context.Categories.FindAsync(id);

        if (categories == null)
        {
            return NotFound();
        }

        return categories;
    }

    // PUT: api/Categories/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategories(int? id, CategoryDTO dto)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.id == id);

        if (category == null)
        {
            return NotFound();
        }

        category.name = dto.name;

        _context.Categories.Update(category);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoriesExists(id))
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
            result = category
        });
    }

    // POST: api/Categories
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Categories>> PostCategories(CategoryDTO dto)
    {
        var category = new Categories
        {
            name = dto.name,
        };

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCategories", new { id = category.id }, category);
    }

    // DELETE: api/Categories/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategories(int? id)
    {
        var categories = await _context.Categories.FindAsync(id);
        if (categories == null)
        {
            return NotFound();
        }

        _context.Categories.Remove(categories);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CategoriesExists(int? id)
    {
        return _context.Categories.Any(e => e.id == id);
    }
}
