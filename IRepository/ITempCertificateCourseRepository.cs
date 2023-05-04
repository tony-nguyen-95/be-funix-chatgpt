using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface ITempCertificateCourseRepository
    {
        Task Add(TempCertificateCourse entity);
        Task Add(List<TempCertificateCourse> entities);
    }
}
