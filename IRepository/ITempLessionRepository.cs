using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface ITempLessionRepository
    {
        Task<List<TempLession>> GetByCourseId(Guid TempCourseId);
        Task<List<TempLession>> GetBySubjectId(Guid TempSubjectId);
        Task Add(List<TempLession> entities);
        Task Add(TempLession entity);
        void Update(TempLession entity);
        void Update(List<TempLession> entities);
    }
}
