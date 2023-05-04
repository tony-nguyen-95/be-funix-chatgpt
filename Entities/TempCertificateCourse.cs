using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("TempCertificateCourse")]
    public class TempCertificateCourse
    {
        public Guid TempCertificateCourseId { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Code { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        #region Relationship
        [ForeignKey("TempCourseId")]
        public Guid TempCourseId { get; set; }
        public TempCourse TempCourse { get; set; }
        [ForeignKey("TempCertificateId")]
        public Guid TempCertificateId { get; set; }
        public TempCertificate TempCertificate { get; set; }
        #endregion
    }
}
