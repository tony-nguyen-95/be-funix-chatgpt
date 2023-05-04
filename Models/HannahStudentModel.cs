namespace Funix.HannahAssistant.Api.Models
{
    public class HannahStudentModel
    {
        public Guid HannahId { get; set; }
        public List<Guid> StudentIds { get; set; }
        public DateTime StartDate { get; set; }
    }
}
