using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("TempSubject")]
    public class TempSubject
    {
        [Key]
        public Guid TempSubjectId { get; set; }
        public int No { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Code { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        #region Relationship
        [ForeignKey("TempCourseId")]
        public Guid TempCourseId { get; set; }
        public TempCourse TempCourse { get; set; }
        public ICollection<TempLession> TempLessions { get; set; }
        #endregion
    }
}
