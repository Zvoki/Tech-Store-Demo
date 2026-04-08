namespace WebApi.EfCore;

public class Sale
{
    public int Id { get; set; }
    public string? SaleNumber { get; set; }   // S0001

    // Relación con Client
    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;

    public decimal TotalPrice { get; set; }
    public int TotalProducts { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Relación: una venta tiene muchos items
    public List<SaleItem> Items { get; set; } = new();
}