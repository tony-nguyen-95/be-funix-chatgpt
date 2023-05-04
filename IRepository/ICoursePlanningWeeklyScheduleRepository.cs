using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface ICoursePlanningWeeklyScheduleRepository
    {
        Task<List<CoursePlanningWeeklySchedule>> GetByStudentId(Guid StudentId);
        Task<CoursePlanningWeeklySchedule?> Get(Guid Id);
        Task Add(CoursePlanningWeeklySchedule entity);
        Task Add(List<CoursePlanningWeeklySchedule> entities);
        void Update(CoursePlanningWeeklySchedule entity);
    }
}
