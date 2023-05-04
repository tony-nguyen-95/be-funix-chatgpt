namespace Funix.HannahAssistant.Api.Models
{
    public class ChangeHannahModel
    {
        public Guid StudentId { get; set; }
        public Guid CurrentHannahId { get; set; }
        public Guid HannahId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
