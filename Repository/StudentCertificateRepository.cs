using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;

namespace Funix.HannahAssistant.Api.Repository
{
    public class StudentCertificateRepository : IStudentCertificateRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public StudentCertificateRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task Add(StudentCertificate entity)
        {
            await DbContext.StudentCertificates.AddAsync(entity);
        }
    }
}
