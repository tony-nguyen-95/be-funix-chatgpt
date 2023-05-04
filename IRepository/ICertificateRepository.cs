using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface ICertificateRepository
    {
        Task<Certificate?> GetByStudentId(Guid StudentId);
        Task<Certificate?> GetByCode(string Code);
        Task<Certificate?> Get(Guid CertificateId);
        Task<List<Certificate>> GetCertificates();
        Task Add(Certificate entity);
        void Update(Certificate entity);
        void Update(List<Certificate> entities);
    }
}
