using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Funix.HannahAssistant.Api.Repository
{
    public class TempCourseRepository : ITempCourseRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public TempCourseRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<TempCourse>> GetByCertificateId(Guid CertificateId)
        {
            return await DbContext.TempCertificateCourses
                .Include(x => x.TempCourse)
                .Where(x => x.TempCertificateId.Equals(CertificateId)).Select(x => x.TempCourse).Distinct().ToListAsync();
        }

        public async Task<List<TempCourse>> Get()
        {
            return await DbContext.TempCourses.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task Add(TempCourse entity)
        {
            await DbContext.TempCourses.AddAsync(entity);
        }

        public async Task Add(List<TempCourse> entites)
        {
            await DbContext.TempCourses.AddRangeAsync(entites);
        }

        public void Update(TempCourse entity)
        {
            DbContext.TempCourses.Update(entity);
        }

        public void Update(List<TempCourse> entities)
        {
            DbContext.TempCourses.UpdateRange(entities);
        }
    }
}
