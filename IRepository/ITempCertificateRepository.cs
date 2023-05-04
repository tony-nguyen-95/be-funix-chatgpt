using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface ITempCertificateRepository
    {
        Task<TempCertificate?> Get(Guid TempCertificateId);
        Task<List<TempCertificate>> GetCertificates();
        Task Add(TempCertificate entity);
        void Update(TempCertificate entity);
        void Update(List<TempCertificate> entities);
    }
}
