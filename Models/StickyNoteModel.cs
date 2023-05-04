namespace Funix.HannahAssistant.Api.Models
{
    public class StickyNoteModel
    {
        public Guid HannahStudentId { get; set; }
        public Guid StickyNoteId { get; set; }
        public Guid StudentContactId { get; set; }
        public string Content { get; set; }
    }
}
