using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.EfCore;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyController : ControllerBase
    {
        private readonly EF_DataContext _context;

        public BuyController(EF_DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Buy([FromBody] BuyRequestDto request)
        {
            if (request.Client == null || request.Items == null || request.Items.Count == 0)
                return BadRequest(new { success = false, message = "Invalid payload" });

            // 1) Crear cliente
            var client = new Client
            {
                FirstName = request.Client.FirstName,
                LastName = request.Client.LastName,
                Email = request.Client.Email,
                Phone = request.Client.Phone,
                Street = request.Client.Street,
                Postcode = request.Client.Postcode,
                City = request.Client.City,
                Country = request.Client.Country,
                WantsNewsletter = request.Client.WantsNewsletter,
                CreatedAt = DateTime.UtcNow
            };

            _context.Clients.Add(client);
            _context.SaveChanges();

            // Generar ClientNumber tipo C0001
            client.ClientNumber = $"C{client.Id:D4}";
            _context.SaveChanges();

            // 2) Calcular totales
            var totalPrice = request.Items.Sum(i => i.PriceTotal);
            var totalProducts = request.Items.Sum(i => i.Quantity);

            // 3) Crear venta (Order)
            var sale = new Sale
            {
                ClientId = client.Id,
                TotalPrice = totalPrice,
                TotalProducts = totalProducts,
                CreatedAt = DateTime.UtcNow
            };

            _context.Sales.Add(sale);
            _context.SaveChanges();

            // Generar SaleNumber tipo S0001
            sale.SaleNumber = $"S{sale.Id:D4}";
            _context.SaveChanges();

            // 4) Crear SaleItems
            var items = request.Items.Select(i => new SaleItem
            {
                SaleId = sale.Id,
                SaleNumber = sale.SaleNumber!,
                Sku = i.Sku,
                ProductName = i.ProductName,
                Quantity = i.Quantity,
                PriceUnit = i.PriceUnit,
                PriceTotal = i.PriceTotal
            }).ToList();

            _context.SaleItems.AddRange(items);
            _context.SaveChanges();

            // 5) Respuesta final
            return Ok(new
            {
                success = true,
                saleId = sale.Id,
                saleNumber = sale.SaleNumber,
                clientNumber = client.ClientNumber
            });
        }
    }
}