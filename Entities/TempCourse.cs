using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("TempCourse")]
    public class TempCourse
    {
        [Key]
        public Guid TempCourseId { get; set; }
        public int No { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Code { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int TotalWeekLearning { get; set; }
        #region Relationship
        public ICollection<TempCertificateCourse> TempCertificateCourses { get; set; }
        public ICollection<TempSubject> TempSubjects { get; set; }
        public ICollection<TempCourseWeeklySchedule> WeeklySchedules { get; set; }
        #endregion
    }
}
