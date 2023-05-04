using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface ILessionRepository
    {
        Task<List<Lession>> GetLessionDoneByStudentId(Guid StudentId);
        Task<Lession?> Get(Guid LessionId);
        Task<List<Lession>> GetBySubjectId(Guid SubjectId);
        Task<Lession?> GetByStudentId(Guid StudentId);
        Task Add(Lession entity);
        Task Add (List<Lession> entities);
        void Update(Lession entity);
    }
}
