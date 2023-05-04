using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface IStudentContactRepository
    {
        Task<StudentContact?> Get(Guid StudentContactId);
        Task<List<StudentContact>> GetByStudentId(Guid StudentId);
        Task<List<StudentContact>> Get(List<Guid> Ids);
        Task Add(StudentContact entity);
        void Update(StudentContact entity);
        void Update(List<StudentContact> entities);
    }
}
