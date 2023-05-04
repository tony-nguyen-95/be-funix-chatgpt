using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;

namespace Funix.HannahAssistant.Api.Repository
{
    public class CertificateRepository : ICertificateRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public CertificateRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<Certificate?> GetByStudentId(Guid StudentId)
        {
            return await DbContext
                .StudentCertificates.Include(x => x.Certificate).Where(x => x.StudentId.Equals(StudentId))
                .Select(x => x.Certificate).FirstOrDefaultAsync();
        }

        public async Task<Certificate?> GetByCode(string Code)
        {
            return await DbContext.Certificates
                .Where(x => x.Code.ToLower().Equals(Code.ToLower()) && !x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<Certificate?> Get(Guid CertificateId)
        {
            return await DbContext.Certificates
                .Where(x => x.CertificateId.Equals(CertificateId) && !x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<List<Certificate>> GetCertificates()
        {
            return await DbContext.Certificates.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task Add(Certificate entity)
        {
            await DbContext.Certificates.AddAsync(entity);
        }

        public void Update(Certificate entity)
        {
            DbContext.Certificates.Update(entity);
        }

        public void Update(List<Certificate> entities)
        {
            DbContext.Certificates.UpdateRange(entities);
        }
    }
}
