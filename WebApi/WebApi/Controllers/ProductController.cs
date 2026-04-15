using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.EfCore;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly EF_DataContext _context;

        public ProductController(EF_DataContext context)
        {
            _context = context;
        }
        // GET api/product?page=1&pageSize=10
        [HttpGet]
        public IActionResult Get([FromQuery] int page = 1, [FromQuery] int pageSize = 50)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;

            var query = _context.Products
                .Include(p => p.Category)
                .AsQueryable();

            // PAGINACIÓN REAL
            var products = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Cortar loop
            foreach (var p in products)
            {
                if (p.Category != null)
                    p.Category.Products = new List<Product>();
            }

            // Defaults
            foreach (var p in products)
            {
                if (p.Brand == null)
                {
                    p.Brand = p.CategoryId == 1 ? "I-Smart"
                            : p.CategoryId == 2 ? "I-Gamer"
                            : "Unknown";
                }

                if (p.Description == null)
                {
                    p.Description = p.CategoryId == 1
                        ? "A next‑generation smartphone designed for speed, style and everyday performance."
                        : p.CategoryId == 2
                        ? "A high‑performance gaming laptop built for power, cooling and immersive gameplay."
                        : "A premium tech product designed for modern users.";
                }
            }

            return Ok(products);
        }


        // GET api/product/ID
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
        var product = _context.Products
        .Include(p => p.Category)
        .FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            // 🔥 CORTA EL LOOP SOLO PARA ESTE PRODUCTO
            if (product.Category != null)
            {
                product.Category.Products = new List<Product>();
            }


            if (product.Brand == null)    {
        product.Brand = product.CategoryId == 1 ? "I-Smart"
                       : product.CategoryId == 2 ? "I-Gamer"
                       : "Unknown";
    }
            // DESCRIPTION
            if (product.Description == null)
            {
                product.Description = product.CategoryId == 1
                    ? "A next‑generation smartphone designed for speed, style and everyday performance."
                    : product.CategoryId == 2
                    ? "A high‑performance gaming laptop built for power, cooling and immersive gameplay."
                    : "A premium tech product designed for modern users.";
            }

            return Ok(product);
        }

        // GET api/product/search?q=...
        [HttpGet("search")]
        public IActionResult Search([FromQuery] string q)
        {
            if (string.IsNullOrWhiteSpace(q))
                return BadRequest("Query is required.");

            q = q.ToLower().Trim();

            // Traemos todos los productos con su categoría
            var products = _context.Products
                .Include(p => p.Category)
                .ToList();
            foreach (var p in products)
            {
                if (p.Brand == null)
                {
                    p.Brand = p.CategoryId == 1 ? "I-Smart"
                            : p.CategoryId == 2 ? "I-Gamer"
                            : "Unknown";
                }
                // DESCRIPTION

                if (p.Description == null)
                {
                    p.Description = p.CategoryId == 1
                        ? "A next‑generation smartphone designed for speed, style and everyday performance."
                        : p.CategoryId == 2
                        ? "A high‑performance gaming laptop built for power, cooling and immersive gameplay."
                        : "A premium tech product designed for modern users.";
                }
            }
            // 1) Intentar SKU exacto (aaa001, bbb003, etc.)
            var main = products.FirstOrDefault(p => p.Sku.ToLower() == q);

            // 2) Sinónimos por categoría
            var phoneWords = new[] { "phone", "smartphone", "mobile", "i-smart", "ismart" };
            var laptopWords = new[] { "laptop", "pc", "gamer", "gaming", "i-gaming", "igaming" };

            if (main == null)
            {
                if (phoneWords.Contains(q))
                {
                    main = products.FirstOrDefault(p => p.Category.Name == "Mobile");
                }
                else if (laptopWords.Contains(q))
                {
                    main = products.FirstOrDefault(p => p.Category.Name == "Laptop");
                }
            }

            // 3) Búsqueda por nombre / brand / sku parcial
            if (main == null)
            {
                main = products.FirstOrDefault(p =>
                    (p.Name + " " + p.Brand + " " + p.Sku)
                        .ToLower()
                        .Contains(q)
                );
            }

            // Si no encontramos nada
            if (main == null)
            {
                return Ok(new
                {
                    mainProduct = (object?)null,
                    similarProducts = new List<Product>()
                });
            }

            // 4) Productos similares: misma categoría, distinto id, máx 6
            var similar = products
                .Where(p => p.CategoryId == main.CategoryId && p.Id != main.Id)
                .Take(6)
                .ToList();

            return Ok(new
            {
                mainProduct = main,
                similarProducts = similar
            });
        }

        // POST api/product
        [HttpPost]
        [Authorize]

        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            product.PublishDate = DateTime.UtcNow;

            _context.Products.Add(product);
            _context.SaveChanges();

            return Ok(product);
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        [Authorize]

        public IActionResult Put(int id, Product updated)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            product.Name = updated.Name;
            product.Description = updated.Description;
            product.ImageUrl = updated.ImageUrl;
            product.Brand = updated.Brand;
            product.Sku = updated.Sku;
            product.Price = updated.Price;
            product.PublishDate = updated.PublishDate;

            _context.SaveChanges();
            return Ok(product);
        }
        // DELETE api/product/5
        [HttpDelete("{id}")]
        [Authorize]

        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(new { message = "Product deleted successfully" });
        }
    }
}
