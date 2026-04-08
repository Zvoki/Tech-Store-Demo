using System.Text.Json.Serialization;

namespace WebApi.EfCore
{
    public class Client
    {
        public int Id { get; set; }
        public string? ClientNumber { get; set; }   // C0001
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string Street { get; set; } = null!;
        public string Postcode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? Country { get; set; }
        public bool WantsNewsletter { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Relación: un cliente tiene muchas ventas
        [JsonIgnore]
        public List<Sale> Sales { get; set; } = new();
    }
}