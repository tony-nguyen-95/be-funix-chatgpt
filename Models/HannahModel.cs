namespace Funix.HannahAssistant.Api.Models
{
    public class HannahModel
    {
        public Guid HannahId { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid UserId { get; set; }
    }
}
