namespace Funix.HannahAssistant.Api.Models
{
    public class StudentContactModel
    {
        public Guid StudentId { get; set; }
        public Guid StudentContactId { get; set; }
        public int ContactType { get; set; }
        public string Name { get; set; }
    }
}
