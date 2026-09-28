using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using konyvtar.Models;
using konyvtar.Config;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly DatabaseContext _context;
    public BooksController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBook()
    {
        return await _context.Books.ToListAsync();
    }

    // GET: api/Book/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    // PUT: api/Book/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBook(int? id, BookDTO dto)
    {

        Book book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

        if (book == null) NotFound();

        book.Title = dto.Title;
        book.Author = dto.Author;
        book.PublicationYear = dto.PublicationYear;
        book.Available = dto.Available;

        _context.Books.Update(book);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BookExists(id))
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
            result = book
        });
    }

    // POST: api/Book
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Book>> PostBook(BookDTO dto)
    {
        Book book = new Book {
            Title = dto.Title,
            Author = dto.Author,
            PublicationYear = dto.PublicationYear,
            Available = dto.Available,
        };

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBook", new { id = book.Id }, book);
    }

    // DELETE: api/Book/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int? id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BookExists(int? id)
    {
        return _context.Books.Any(e => e.Id == id);
    }
}
