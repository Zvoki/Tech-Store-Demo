using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.EfCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly EF_DataContext _context;

        public SaleController(EF_DataContext context)
        {
            _context = context;
        }

        // GET: api/sale
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sales = await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Items)
                .ToListAsync();

            return Ok(sales);
        }

        // GET: api/sale/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sale = await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sale == null)
                return NotFound(new { message = "Sale not found" });

            return Ok(sale);
        }

        // DELETE: api/sale/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sale = await _context.Sales
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sale == null)
                return NotFound(new { message = "Sale not found" });

            // Primero borrar los items
            _context.SaleItems.RemoveRange(sale.Items);

            // Luego borrar la venta
            _context.Sales.Remove(sale);

            await _context.SaveChangesAsync();

            return Ok(new { message = "Sale and items deleted successfully" });
        }
    }
}