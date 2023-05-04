using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("Lession")]
    public class Lession
    {
        [Key]
        public Guid LessionId { get; set; }
        public int No { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Code { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(1000)")]
        public string? Description { get; set; }
        public DateTime? DoneDate { get; set; }
        public int Scores { get; set; }
        public LessionType LessionType { get; set; }
        public bool IsDeleted { get; set; }
        #region Relationship
        [ForeignKey("SubjectId")]
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        #endregion
    }

    public enum LessionType 
    {
        Quiz = 1,
        Lab = 2,
        Assignment =3,
        ProgressTest = 4,
        Final = 5
    }
}
