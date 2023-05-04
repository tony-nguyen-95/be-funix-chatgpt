using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        public Guid SubjectId { get; set; }
        public int No { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Code { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(1000)")]
        public string Description { get; set; }
        public SubjectStatus Status { get; set; }
        public bool IsDeleted { get; set; }
        #region Relationship
        [ForeignKey("CourseId")]
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<Lession> Lessions { get; set; }
        #endregion
    }
    public enum SubjectStatus
    {
        Pending = 1,
        Learning = 2,
        Done = 3,
    }
}
