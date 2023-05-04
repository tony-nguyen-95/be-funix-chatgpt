using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("HannahStudent")]
    public class HannahStudent
    {
        public Guid HannahStudentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsSupport { get; set; }
        #region Relationship
        [ForeignKey("HannahId")]
        public Guid HannahId { get; set; }
        public Hannah Hannah { get; set; }
        [ForeignKey("StudentId")]
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public ICollection<StickyNote> StickyNotes { get; set; }
        #endregion
    }
}
