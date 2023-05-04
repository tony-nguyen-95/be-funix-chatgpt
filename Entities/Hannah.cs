using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("Hannah")]
    public class Hannah
    {
        [Key]
        public Guid HannahId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        public DateTime? BirthDay { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string? Email { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public bool IsDeleted { get; set; }

        #region Relationship
        public ICollection<HannahStudent> Students { get; set; }
        [ForeignKey("UserId")]
        public Guid? UserId { get; set; }
        public User? User { get; set; }
        #endregion
    }
}
