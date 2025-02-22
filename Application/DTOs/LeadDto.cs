namespace LeadsService.Application.DTOs
{
    public class LeadDto
    {
        public int Id { get; set; }
        public required string ContactFirstName { get; set; }
        public required string ContactFullName { get; set; }
        public required string ContactPhone { get; set; }
        public required string ContactEmail { get; set; }
        public DateTime DateCreated { get; set; }
        public required string Suburb { get; set; }
        public required string Category { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string Status { get; set; }
    }
}
