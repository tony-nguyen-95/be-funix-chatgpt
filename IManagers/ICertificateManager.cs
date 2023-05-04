using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.Models;

namespace Funix.HannahAssistant.Api.IManagers
{
    public interface ICertificateManager
    {
        Task<ApiStatusModel<List<Course>>> GetCourse(Guid StudentId, Guid CertificateId);
        Task<ApiStatusModel<List<Subject>>> GetSubject(Guid CourseId);
        Task<ApiStatusModel<List<Lession>>> GetLession(Guid SubjectId);
        Task<ApiStatusModel<bool>> AddEditCourseWeeklySchedule(AddCoursePlanningWeeklyScheduleModel model);
    }
}
