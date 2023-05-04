using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface IStudentRepository
    {
        Task<List<Student>> Get();
        Task<Student?> Get(Guid StudentId);
        Task<List<Student>> Get(List<Guid> Ids);
        Task Add(Student entity);
        void Update(Student entity);
        void Update(List<Student> entities);
    }
}
