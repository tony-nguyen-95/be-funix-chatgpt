namespace Funix.HannahAssistant.Api.Models
{
    public class ListHannahStudentModel
    {
        public Guid HannahStudentId { get; set; }
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string FunixEmail { get; set; }
        public string FunixId { get; set; }
        public string Certificate { get; set; }
        public DateTime? EndCertificateDate { get; set; }
        public string SubjectLessionLearning { get; set; }
        public DateTime SupportStartDate { get; set; }
        public int Status { get; set; }
        public int Progress { get; set; }
        public List<StudentContactModel> Contacts { get; set; }
    }

    public class GetStudentByHannahConditional 
    { 
        public Guid HannahId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public bool IsSupport { get; set; }
    }
}
