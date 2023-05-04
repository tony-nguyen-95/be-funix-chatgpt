using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("TempCertificate")]
    public class TempCertificate
    {
        public Guid TempCertificateId { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Code { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        #region Relationship
        public ICollection<TempCertificateCourse> TempCertificateCourses { get; set; }
        #endregion
    }
}
