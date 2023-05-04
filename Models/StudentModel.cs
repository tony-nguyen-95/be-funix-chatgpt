namespace Funix.HannahAssistant.Api.Models
{
    public class StudentModel
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string FunixId { get; set; }
        public string FunixMail { get; set; }
        public int Status { get; set; }
    }
}
