namespace WebApi.Dto
{
    public class BuyItemDto
    {
        public string Sku { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal PriceUnit { get; set; }
        public decimal PriceTotal { get; set; }
    }
}