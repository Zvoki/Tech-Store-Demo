using System.Text.Json.Serialization;

namespace WebApi.EfCore
{
    public class Category
    {
        public int Id { get; set; }

        // Ej: "Mobile", "Laptop"
        public string Name { get; set; } = null!;

        // Ej: "All smartphones and phones", "All laptops and gaming PCs"
        public string? Description { get; set; }

        // Evita ciclos infinitos al serializar
        [JsonIgnore]
        public List<Product> Products { get; set; } = new();

    }
}