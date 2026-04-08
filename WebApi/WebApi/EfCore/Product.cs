namespace WebApi.EfCore;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string? Brand { get; set; }
    public string Sku { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime PublishDate { get; set; }
    public int? CategoryId { get; set; }
    public Category Category { get; set; } = null!;

}