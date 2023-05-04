using Funix.HannahAssistant.Api.Entities;
using Funix.HannahAssistant.Api.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Funix.HannahAssistant.Api.Repository
{
    public class LessionRepository : ILessionRepository
    {
        private HannahAssistantDbContext DbContext { get; set; }
        public LessionRepository(HannahAssistantDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<Lession?> Get(Guid LessionId)
        {
            return await DbContext.Lessions.Where(x => x.LessionId.Equals(LessionId)).FirstOrDefaultAsync();
        }

        public async Task<List<Lession>> GetBySubjectId(Guid SubjectId)
        {
            return await DbContext.Lessions.Where(x => x.SubjectId.Equals(SubjectId)).ToListAsync();
        }

        public async Task<List<Lession>> GetLessionDoneByStudentId(Guid StudentId)
        {
            var query = (from s in DbContext.StudentCertificates
                         join c in DbContext.Courses on s.CertificateId equals c.CertificateId
                         join su in DbContext.Subjects on c.CourseId equals su.CourseId
                         join l in DbContext.Lessions on su.SubjectId equals l.SubjectId
                         where l.DoneDate.HasValue
                         select l);
            return await query.ToListAsync();
        }

        public async Task<Lession?> GetByStudentId(Guid StudentId)
        {
            var query = (from s in DbContext.StudentCertificates
                        join c in DbContext.Courses on s.CertificateId equals c.CertificateId
                        join su in DbContext.Subjects on c.CourseId equals su.CourseId
                        join l in DbContext.Lessions on su.SubjectId equals l.SubjectId
                        where l.DoneDate.HasValue
                        orderby l.DoneDate.Value descending
                        select l);
            return await query.FirstOrDefaultAsync();
        }

        public async Task Add(Lession entity)
        {
            await DbContext.Lessions.AddAsync(entity);
        }

        public async Task Add(List<Lession> entities)
        {
            await DbContext.Lessions.AddRangeAsync(entities);
        }

        public void Update(Lession entity)
        {
            DbContext.Lessions.Update(entity);
        }
    }
}
