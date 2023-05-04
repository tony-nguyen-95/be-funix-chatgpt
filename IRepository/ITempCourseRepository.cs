using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface ITempCourseRepository
    {
        Task<List<TempCourse>> GetByCertificateId(Guid CertificateId);
        Task<List<TempCourse>> Get();
        Task Add(List<TempCourse> entites);
        Task Add(TempCourse entity);
        void Update(TempCourse entity);
        void Update(List<TempCourse> entities);
    }
}
