using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("Certificate")]
    public class Certificate
    {
        [Key]
        public Guid CertificateId { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Code { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(1000)")]
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        #region Relationship
        public ICollection<StudentCertificate> StudentCertificates { get; set; }
        public ICollection<Course> Courses { get; set; }
        #endregion
    }
}
