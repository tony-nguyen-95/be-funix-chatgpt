using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("StudentContact")]
    public class StudentContact
    {
        [Key]
        public Guid StudentContactId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        [Column(TypeName = "longtext")]
        public string? Note { get; set; }
        public ContactType Type { get;set; }
        public bool IsDeleted { get; set; }

        #region Relationship
        [ForeignKey("StudentId")]
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public ICollection<StickyNote> StickyNotes { get; set; }
        #endregion
    }

    public enum ContactType
    {
        Zalo = 1,
        Discord = 2,
        Facebook = 2,
        Email = 3,
        Viber = 4,
        Telegram = 5,
        Skype = 6,
        PhoneNumber = 7,
        Other = 99
    }
}
