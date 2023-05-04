using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Funix.HannahAssistant.Api.Repository
{
    public class TempCertificateRepository : ITempCertificateRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public TempCertificateRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<TempCertificate?> Get(Guid TempCertificateId)
        {
            return await DbContext.TempCertificates
                .Where(x => x.TempCertificateId.Equals(TempCertificateId) && !x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<List<TempCertificate>> GetCertificates()
        {
            return await DbContext.TempCertificates.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task Add(TempCertificate entity)
        {
            await DbContext.TempCertificates.AddAsync(entity);
        }

        public void Update(TempCertificate entity)
        {
            DbContext.TempCertificates.Update(entity);
        }

        public void Update(List<TempCertificate> entities)
        {
            DbContext.TempCertificates.UpdateRange(entities);
        }
    }
}
