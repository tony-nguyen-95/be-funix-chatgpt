namespace Funix.HannahAssistant.Api.Models
{
    public class AddCoursePlanningWeeklyScheduleModel
    {
        public Guid CoursePlanningWeeklyScheduleId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WeekOfYear { get; set; }
        public int Year { get; set; }
        public int TotalQuiz { get; set; }
        public int TotalLab { get; set; }
        public int TotalPT { get; set; }
        public int TotalAss { get; set; }
        public int TotalFinal { get; set; }
    }
}
