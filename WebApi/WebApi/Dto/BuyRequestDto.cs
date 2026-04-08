namespace WebApi.Dto
{
    public class BuyRequestDto
    {
        public BuyClientDto Client { get; set; } = null!;
        public List<BuyItemDto> Items { get; set; } = new();
    }
}