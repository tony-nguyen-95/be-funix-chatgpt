using Org.BouncyCastle.Pkcs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("StickyNote")]
    public class StickyNote
    {
        [Key]
        public Guid StickyNoteId { get; set; }
        [Column(TypeName = "longtext")]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        #region Relationship
        [ForeignKey("HannahStudentId")]
        public Guid HannahStudentId { get; set; }
        public HannahStudent HannahStudent { get; set; }
        [ForeignKey("StudentContactId")]
        public Guid StudentContactId { get; set; }
        public StudentContact StudentContact { get; set; }
        #endregion
    }
}
