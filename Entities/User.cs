using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string UserName { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Password { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string FunixId { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string FunixEmail { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        //public bool IsDeleted { get; set; }
        #region Relationship
        public Hannah? Hannah { get; set; }
        #endregion
    }
}
