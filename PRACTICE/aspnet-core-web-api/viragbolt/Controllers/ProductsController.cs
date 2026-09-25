using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using viragbolt.Models;
using viragbolt.Config;
using viragbolt.Models.DTO;
using System.Collections.Immutable;

[Route("api/flowers")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly DatabaseContext _context;
    public ProductsController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
    {
        var products = await _context.Products
            .Join(
                _context.Categories,
                product => product.categoryId,
                category => category.id,
                (product, category) => new {
                    product.id,
                    PName = product.name,
                    Category = new {
                        product.categoryId,
                        category.name,
                    },
                    product.description,
                    product.stock,
                    product.price,
                    product.imgUrl,
                })
            .ToListAsync();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Products>> GetProducts(int id)
    {
        var products = await _context.Products
            .Join(
                _context.Categories,
                product => product.categoryId,
                category => category.id,
                (product, category) => new
                {
                    product.id,
                    PName = product.name,
                    Category = new
                    {
                        product.categoryId,
                        category.name,
                    },
                    product.description,
                    product.stock,
                    product.price,
                    product.imgUrl,
                }
            )
            .Where(p => p.id == id)
            .ToListAsync();

        if (products == null) return NotFound();

        return Ok(products);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducts(int? id, ProductDTO dto)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.id == id);

        if(product == null) { 
            return NotFound(new {
                message = "A virág nem található!",
            }); 
        }

        product.name = dto.name;
        product.categoryId = dto.categoryId;
        product.description = dto.description;
        product.stock = dto.stock;
        product.price = dto.price;
        product.imgUrl = dto.imgUrl;

        _context.Products.Update(product);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductsExists(id))
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
            result = product
        });
    }

    [HttpPost]
    public async Task<ActionResult<Products>> PostProducts(ProductDTO dto)
    {
        var product = new Products
        {
            name = dto.name,
            categoryId = dto.categoryId,
            description = dto.description,
            stock = dto.stock,
            price = dto.price,
            imgUrl = dto.imgUrl
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProducts", new { id = product.id }, product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducts(int? id)
    {
        var products = await _context.Products.FindAsync(id);
        if (products == null)
        {
            return NotFound();
        }

        _context.Products.Remove(products);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductsExists(int? id)
    {
        return _context.Products.Any(e => e.id == id);
    }
}
