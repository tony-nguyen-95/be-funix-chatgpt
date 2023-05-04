using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("TempCourseWeeklySchedule")]
    public class TempCourseWeeklySchedule
    {
        [Key]
        public Guid TempCourseScheduleId { get; set; }
        public int No { get; set; }
        public int TotalQuiz { get; set; }
        public int TotalLab { get; set; }
        public int TotalPT { get; set; }
        public int TotalAssignment { get; set; }
        public bool IsFinalExam { get; set; }
        public bool IsDeleted { get; set; }
        #region Relationship
        [ForeignKey("TempCourseId")]
        public Guid TempCourseId { get; set; }
        public TempCourse TempCourse { get; set; }
        #endregion
    }
}
