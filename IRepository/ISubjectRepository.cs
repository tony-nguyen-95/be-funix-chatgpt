using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetByCourseId(Guid CourseId);
        Task Add(Subject entity);
        Task Add(List<Subject> entities);
    }
}
