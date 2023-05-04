namespace Funix.HannahAssistant.Api.Models
{
    public class AddStudentCertificateModel
    {
        public Guid StudentId { get; set; }
        public Guid TempCertificateId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
