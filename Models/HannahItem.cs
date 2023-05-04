namespace Funix.HannahAssistant.Api.Models
{
    public class HannahItem
    {
        public Guid HannahId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int TotalStudentSupport { get; set; }
    }
}
