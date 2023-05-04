using Org.BouncyCastle.Bcpg;

namespace Funix.HannahAssistant.Api.Models
{
    public class StudentItem
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string FunixId { get; set; }
        public string FunixEmail { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public Guid HannahId { get; set; }
    }
}
