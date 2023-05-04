using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public Guid CourseId { get; set; }
        public int No { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Code { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime PlanStartDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        //public int TotalWeekLearning { get; set; }
        public CourseStatus Status { get; set; }
        public bool IsDeleted { get; set; }
        #region Relationship
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<CoursePlanningWeeklySchedule> WeeklySchedules { get; set; }
        [ForeignKey("CertificateId")]
        public Guid CertificateId { get; set; }
        public Certificate Certificate { get; set; }
        #endregion
    }

    public enum CourseStatus
    {
        Pending = 1,
        Learning = 2,
        Done = 3
    }
}
