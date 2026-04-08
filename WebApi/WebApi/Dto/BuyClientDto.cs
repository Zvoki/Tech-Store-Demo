namespace WebApi.Dto
{
    public class BuyClientDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string Street { get; set; } = null!;
        public string Postcode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? Country { get; set; }
        public bool WantsNewsletter { get; set; }
    }
}