using Funix.HannahAssistant.Api.Entities;

namespace Funix.HannahAssistant.Api.IRepository
{
    public interface IStudentCertificateRepository
    {
        Task Add(StudentCertificate entity);
    }
}
