using Microsoft.AspNetCore.Mvc;
using WebApi.EfCore;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly EF_DataContext _context;

        public ClientController(EF_DataContext context)
        {
            _context = context;
        }

        // GET api/client
        [HttpGet]
        public IActionResult Get()
        {
            var clients = _context.Clients.ToList();
            return Ok(clients);
        }

        // GET api/client/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var client = _context.Clients.Find(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        // POST api/client
        [HttpPost]
        public IActionResult Post(ClientModel model)
        {
            var client = new Client
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone,
                Street = model.Street,
                Postcode = model.Postcode,
                City = model.City,
                Country = model.Country,
                WantsNewsletter = model.WantsNewsletter,
                CreatedAt = DateTime.UtcNow
            };

            // Generar ClientNumber automáticamente (versión robusta y compatible con EF)
            var lastNumber = _context.Clients
                .Where(c => c.ClientNumber != null && c.ClientNumber.Length > 1)
                .AsEnumerable() // a partir de aquí es LINQ en memoria
                .Select(c =>
                {
                    var num = c.ClientNumber!.Substring(1);
                    return int.TryParse(num, out var n) ? n : 0;
                })
                .DefaultIfEmpty(0)
                .Max();

            client.ClientNumber = $"C{(lastNumber + 1).ToString("D4")}";

            _context.Clients.Add(client);
            _context.SaveChanges();

            return Ok(client);
        }

        // PUT api/client/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ClientModel model)
        {
            var client = _context.Clients.Find(id);
            if (client == null)
                return NotFound();
            client.ClientNumber = model.ClientNumber;
            client.FirstName = model.FirstName;
            client.LastName = model.LastName;
            client.Email = model.Email;
            client.Phone = model.Phone;
            client.Street = model.Street;
            client.Postcode = model.Postcode;
            client.City = model.City;
            client.Country = model.Country;
            client.WantsNewsletter = model.WantsNewsletter;
            client.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();

            return Ok(client);
        }

        // DELETE api/client/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var client = _context.Clients.Find(id);
            if (client == null)
                return NotFound();

            _context.Clients.Remove(client);
            _context.SaveChanges();

            return NoContent();
        }
    }
}