namespace Funix.HannahAssistant.Api.Models
{
    public class DashboardModel
    {
        public int TotalStudent { get; set; }
        public int TotalLearningStudent { get; set; }
        public int TotalDoneStudent { get; set; }
        public int TotalOnScheduleStudent { get; set; }
        public int TotalDelayProgressStudent { get; set; }
        public int TotalOverProgressStudent { get; set; }
        public int TotalStickyNotePerWeek { get; set; }
        public int TotalStickyNotePerMonth { get; set; }
        public int TotalStickyNotePerYear { get; set; }
    }
}
