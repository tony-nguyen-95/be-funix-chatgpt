using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("StudentCertificate")]
    public class StudentCertificate
    {
        [Key]
        public Guid StudentCertificateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime PlanStartDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        #region Relationship
        [ForeignKey("StudentId")]
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        [ForeignKey("CertificateId")]
        public Guid CertificateId { get; set; }
        public Certificate Certificate { get; set; }
        #endregion
    }
}
