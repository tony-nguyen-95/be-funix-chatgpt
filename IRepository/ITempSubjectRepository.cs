using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface ITempSubjectRepository
    {
        Task<List<TempSubject>> Get();
        Task<List<TempSubject>> GetByCourseId(Guid TempCourseId);
        Task Add(TempSubject entity);
        Task Add(List<TempSubject> entities);
        void Update(TempSubject entity);
        void Update(List<TempSubject> entities);
    }
}
