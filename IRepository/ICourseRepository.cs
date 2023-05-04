using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface ICourseRepository
    {
        Task<List<Course>> Get(Guid StudentId, Guid CertificateId);
        Task Add(Course entity);
        Task Add(List<Course> entities);
    }
}
