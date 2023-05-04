using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;

namespace Funix.HannahAssistant.Api.Repository
{
    public class TempCertificateCourseRepository : ITempCertificateCourseRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public TempCertificateCourseRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task Add(TempCertificateCourse entity)
        {
            await DbContext.TempCertificateCourses.AddAsync(entity);
        }

        public async Task Add(List<TempCertificateCourse> entities)
        {
            await DbContext.TempCertificateCourses.AddRangeAsync(entities);
        }
    }
}
