using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("TempLession")]
    public class TempLession
    {
        [Key]
        public Guid TempLessionId { get; set; }
        public int No { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Code { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        public TempLessionType Type { get; set; }
        public bool IsDeleted { get; set; }
        #region Relationship
        [ForeignKey("TempSubjectId")]
        public Guid TempSubjectId { get; set; }
        public TempSubject TempSubject { get; set; }
        #endregion
    }

    public enum TempLessionType
    {
        Quiz = 1,
        Lab = 2,
        Assignment = 3,
        ProgressTest = 4,
        Final = 5
    }
}
