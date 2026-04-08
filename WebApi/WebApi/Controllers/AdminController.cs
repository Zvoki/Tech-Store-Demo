using Microsoft.AspNetCore.Mvc;
using WebApi.EfCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly EF_DataContext _context;

        public AdminController(EF_DataContext context)
        {
            _context = context;
        }

        [HttpDelete("reset")]
        public IActionResult ResetDatabase()
        {
            // 1) Borrar primero los hijos (SaleItems)
            _context.SaleItems.RemoveRange(_context.SaleItems);

            // 2) Luego las ventas
            _context.Sales.RemoveRange(_context.Sales);

            // 3) Luego los clientes
            _context.Clients.RemoveRange(_context.Clients);

            // (Opcional) borrar productos si también quieres limpiar eso:
            // _context.Products.RemoveRange(_context.Products);

            _context.SaveChanges();

            return Ok(new { message = "Database cleaned successfully" });
        }
    }
}