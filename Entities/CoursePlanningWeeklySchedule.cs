using System.ComponentModel.DataAnnotations.Schema;

namespace Funix.HannahAssistant.Api.Entities
{
    [Table("CoursePlanningWeeklySchedule")]
    public class CoursePlanningWeeklySchedule
    {
        public Guid CoursePlanningWeeklyScheduleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WeekOfYear { get; set; }
        public int Year { get; set; }
        public int TotalQuiz { get; set; }
        public int TotalLab { get; set; }
        public int TotalPT { get; set; }
        public int TotalAss { get; set; }
        public int TotalFinal { get; set; }

        #region Relationship
        [ForeignKey("CourseId")]
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        #endregion
    }
}
