using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Funix.HannahAssistant.Api.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public CourseRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<Course>> Get(Guid StudentId, Guid CertificateId)
        {
            var query = (from sc in DbContext.StudentCertificates
                         join c in DbContext.Certificates on sc.CertificateId equals c.CertificateId
                         join co in DbContext.Courses on c.CertificateId equals co.CertificateId
                         where sc.CertificateId.Equals(CertificateId) && sc.StudentId.Equals(StudentId)
                         select co);
            return await query.ToListAsync();
        }

        public async Task Add(Course entity)
        {
            await DbContext.Courses.AddAsync(entity);
        }

        public async Task Add(List<Course> entities)
        {
            await DbContext.Courses.AddRangeAsync(entities);
        }
    }
}
