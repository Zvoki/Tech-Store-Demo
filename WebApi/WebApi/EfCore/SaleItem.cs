using System.Text.Json.Serialization;

namespace WebApi.EfCore
{
    public class SaleItem
    {
        public int Id { get; set; }

        // Relación con Sale
        public int SaleId { get; set; }

        [JsonIgnore]   // ← ESTO CORTA EL CICLO INFINITO
        public Sale Sale { get; set; } = null!;

        public string SaleNumber { get; set; } = null!;  // S0001
        public string Sku { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal PriceUnit { get; set; }
        public decimal PriceTotal { get; set; }
    }
}