using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using WebApi.EfCore;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly EF_DataContext _context;

        public CategoriesController(EF_DataContext context)
        {
            _context = context;
        }

        // GET /api/categories
        // GET /api/categories?slug=phone
        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? slug)
        {
            var query = _context.Categories
                .Include(c => c.Products)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(slug))
            {
                slug = slug.ToLower().Trim();

                query = query.Where(c =>
                    c.Name.ToLower().Replace(" ", "-") == slug
                );
            }

            var categories = await query.ToListAsync();

            // 👉 Aplicar defaults como en ProductController
            foreach (var c in categories)
            {
                foreach (var p in c.Products)
                {
                    if (p.Brand == null)
                        p.Brand = p.CategoryId == 1 ? "I-Smart"
                                : p.CategoryId == 2 ? "I-Gamer"
                                : "Unknown";

                    if (p.Description == null)
                        p.Description = p.CategoryId == 1
                            ? "A next‑generation smartphone designed for speed, style and everyday performance."
                            : p.CategoryId == 2
                            ? "A high‑performance gaming laptop built for power, cooling and immersive gameplay."
                            : "A premium tech product designed for modern users.";
                }
            }

            return Ok(categories);
        }
        // GET /api/categories/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _context.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
                return NotFound();

            // 👉 Aplicar defaults como en ProductController
            foreach (var p in category.Products)
            {
                if (p.Brand == null)
                    p.Brand = p.CategoryId == 1 ? "I-Smart"
                            : p.CategoryId == 2 ? "I-Gamer"
                            : "Unknown";

                if (p.Description == null)
                    p.Description = p.CategoryId == 1
                        ? "A next‑generation smartphone designed for speed, style and everyday performance."
                        : p.CategoryId == 2
                        ? "A high‑performance gaming laptop built for power, cooling and immersive gameplay."
                        : "A premium tech product designed for modern users.";
            }

            return Ok(category);
        }

        // POST /api/categories
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        // DELETE /api/categories/1
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH /api/categories/{id}
        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Category> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();

            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return NotFound();

            patchDoc.ApplyTo(category, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE /api/categories/{categoryId}/products/{productId}
        [HttpDelete("{categoryId}/products/{productId}")]
        [Authorize]
        public async Task<IActionResult> RemoveProductFromCategory(int categoryId, int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
                return NotFound("Product not found");

            if (product.CategoryId != categoryId)
                return BadRequest("Product does not apply to this category.");


            return NoContent();
        }
    }
}
