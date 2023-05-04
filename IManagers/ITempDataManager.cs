using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.Models;

namespace Funix.HannahAssistant.Api.IManagers
{
    public interface ITempDataManager
    {
        Task<ApiStatusModel<TotalLessionByCourse>> GetTotalLessionByTempCourse(Guid TempCourseId);
        Task<ApiStatusModel<bool>> AddLession(Guid CertificateId);
        Task<ApiStatusModel<bool>> SeedData(int CertIndex);
        Task<ApiStatusModel<List<TempCertificate>>> GetCertificates();
    }
}
