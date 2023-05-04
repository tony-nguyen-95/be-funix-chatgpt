using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string FunixId { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string FunixEmail { get; set; }
        public string? Address { get; set; }
        public StudentStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        #region Relationship
        public ICollection<StudentCertificate> StudentCertificates { get; set; }
        public ICollection<HannahStudent> Hannahs { get; set; }
        public ICollection<StudentContact> Contacts { get; set; }
        public ICollection<StickyNote> StickyNotes { get; set; }
        #endregion
    }

    public enum StudentStatus
    {
        New = 1,
        Learning = 2,
        Pause = 3,
        Reserve = 4,
        Done = 5
    }
}
